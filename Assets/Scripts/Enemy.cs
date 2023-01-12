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

    //Boss values
    [SerializeField] Transform shootPosition;
    GameObject bullet;
    bool shoot = true;

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        score= actorModel.score;
        actorType = actorModel.actorType;
        bullet = actorModel.actorBullets;
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

            if (actorType == SOActorModel.ActorType.BossTeddyBear)
            {
                if (agent.stoppingDistance <= 3.0f) Fire();
            }
        }
    }


    void ChasePlayer()
    {
       if (actorType == SOActorModel.ActorType.BigTeddyBear)
        {
            //agent.destination = GameManager.playerPosition;
        }
        else /*if (actorType == SOActorModel.ActorType.BossTeddyBear)*/
        {
            agent.destination = GameManager.playerPosition;

        }
    }


    public void Die()
    {
        Destroy(gameObject);

        if (actorType == SOActorModel.ActorType.BossTeddyBear)
        {
            GameManager.Instance.GetComponent<ScenesManager>().GameOver();
        }
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

    void Fire()
    {
        if (shoot) StartCoroutine(CreateBullet());
    }

    IEnumerator CreateBullet()
    {
        Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        shoot = false;
        yield return new WaitForSeconds(2.0f);
        shoot = true;
    }
}
