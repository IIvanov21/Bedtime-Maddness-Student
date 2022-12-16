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

    NavMeshAgent agent;

    //Patrol variables
    private Vector3 startPos;//Patrol point A
    private float distanceToPatrolPoint;
    private bool patrolSwitch = true;
    

    GameObject[] patrolPoints;
    GameObject patrolPoint;//Patrol point B

    //Chase variables
    private float distanceToPlayer;
    private Vector3 directionToPlayer;
    float angle;
    [SerializeField] private float minDistanceToPlayer = 10.0f;
    private bool stateSwitch = true;// true=Patrol and false=Chase

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        if (actorType == SOActorModel.ActorType.BigTeddyBear)
        {
            patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
            patrolPoint = patrolPoints[Random.Range(0, patrolPoints.Length - 1)];
            startPos = transform.position; //Capture Patrol point A
        }
    }

    void Update()
    {
  
        ChasePlayer();

        Patrol();

        LookingAtPlayer();
    }

    void ChasePlayer()
    {
        if (actorType == SOActorModel.ActorType.SmallTeddyBear)
        {
            agent.destination = GameManager.playerPosition;
        }
        else if (actorType == SOActorModel.ActorType.BigTeddyBear && !stateSwitch)
        {
            agent.destination = GameManager.playerPosition;
        }
    }

    void Patrol()
    {
        if (actorType == SOActorModel.ActorType.BigTeddyBear && stateSwitch)
        {
            if (patrolSwitch)//If this is true we are going towards patrol point B
            {
                //Calculating the distance between the enemy and patrol point B
                distanceToPatrolPoint = Vector3.Distance(transform.position, patrolPoint.transform.position);
                //Checks if the distance is smaller than stopping distance, if it is true it means that we have 
                //reached patrol point B
                if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = false;
                //Constantly sets the agents destination to the patrol point
                agent.destination = patrolPoint.transform.position;
            }
            else if (!patrolSwitch)
            {
                //Calculating the distance between the enemy and patrol point A
                distanceToPatrolPoint = Vector3.Distance(transform.position, startPos);
                //Checks if the distance is smaller than stopping distance, if it is true it means that we have 
                //reached patrol point A
                if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = true;
                //Constantly sets the agents destination to the patrol point
                agent.destination = startPos;
            }
        }
    }

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed*GameManager.difficulty;
        health = actorModel.health*GameManager.difficulty;
        hitPower = actorModel.hitPower*GameManager.difficulty;
        score= actorModel.score;
        actorType=actorModel.actorType;
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
        if (other.CompareTag("Player"))
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

    void LookingAtPlayer()
    {
        //Provide a directional vector towards the player
        directionToPlayer = transform.position - GameManager.playerPosition;
        //Calculate an angel to check if we are looking at the player
        angle = Vector3.Angle(transform.position, directionToPlayer);
        //Calculate the distanceToPlayer
        distanceToPlayer = Vector3.Distance(transform.position, GameManager.playerPosition);

        if (distanceToPlayer < minDistanceToPlayer && FacingPlayer())
        {
            stateSwitch = false;
        }
        else
        {
            stateSwitch = true;
        }
            
    }

    bool FacingPlayer()
    {
        if (Mathf.Abs(angle) > 90.0f && Mathf.Abs(angle) < 270.0f) return true;
        else return false;
    }
    
}
