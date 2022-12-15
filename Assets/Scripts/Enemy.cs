using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IActorTemplate
{
    //Default values
    float speed;
    int health;
    int hitPower;
    int score;
    SOActorModel.ActorType actorType;
    //Agent
    NavMeshAgent agent;
    //Patrol variables
    GameObject[] patrolPoints;
    GameObject patrolPoint;//Patrol Point B

    private float distanceToPatrolPoint;
    private Vector3 startingPos;//Patrol Point A
    private bool patrolSwitch=true;//Simple switch between the two patrol points

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        score= actorModel.score;
        actorType = actorModel.actorType;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (actorType == SOActorModel.ActorType.BigTeddyBear)
        {
            //Loading all of our Patrol points and picking a random one
            patrolPoints = GameObject.FindGameObjectsWithTag("Patrol");
            patrolPoint = patrolPoints[Random.Range(0, patrolPoints.Length - 1)];//Patrol point B

            startingPos = transform.position; //Patrol point A
        }
    }

    void Update()
    {
        if (GameManager.State == GameState.Play)
        {
            ChasePlayer();

            Patrol();
        }
    }


    void ChasePlayer()
    {
        if (actorType == SOActorModel.ActorType.SmallTeddyBear)
        {
            agent.destination = GameManager.playerPosition;
        }
        else if (actorType == SOActorModel.ActorType.BigTeddyBear)
        {
            //agent.destination = GameManager.playerPosition;
        }
    }


    public void Die()
    {
        Destroy(gameObject);
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (health >= 1)
            {
                TakeDamage(other.GetComponent<IActorTemplate>().SendDamage());
            }

            if (health == 0)
            {
                GameManager.Instance.GetComponent<ScoreManager>().SetScore(score);
                Debug.Log("Player's score: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore);
                LevelUI.onScoreUpdate?.Invoke();
                Die();

            }
        }
    }

    void Patrol()
    {
        if (actorType == SOActorModel.ActorType.BigTeddyBear)
        {
            if (patrolSwitch)
            {
                distanceToPatrolPoint = Vector3.Distance(transform.position, patrolPoint.transform.position);//Calculate the distance to the patrol point B
                agent.destination = patrolPoint.transform.position;//Make our enemy go towards patrol point B
                if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = false;//If true switch the patrol point target
            }
            else if (!patrolSwitch)
            {
                distanceToPatrolPoint = Vector3.Distance(transform.position, startingPos);//Caculate the distance to the patrol point A
                agent.destination = startingPos;//Make our enemy go towards patrol point A
                if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = true;
            }
        }
    }
}
