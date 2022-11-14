using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IActorTemplate
{

    //Default values
    float speed;
    int health;
    int hitPower;

    GameObject actor;
    GameObject fire;

    [SerializeField]
    GameObject shootPoint;

    float horizontalInput;
    float verticalInput;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public GameObject Fire
    {
        get { return fire; }
        set { fire = value; }
    }

    GameObject _Player;

    void Start()
    {
        _Player = GameObject.Find("_Player");
    }

    void Update()
    {
        //Creating the Move function
        Move();

        //Create the Attack function
        Attack();
    }

    

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Forward/Backwards movement
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        //Left/Right movement
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);


    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Create a new bullet and pass it player's shoot point reference position and rotation
            GameObject bullet = GameObject.Instantiate(fire, shootPoint.transform.position, shootPoint.transform.rotation);
            bullet.transform.SetParent(_Player.transform);
        }
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health+=incomingDamage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        actor = actorModel.actor;
        fire = actorModel.actorBullets;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //If our health is below 100
            if (health < 100)
            {
                //Suffocation level at start of the game is 0%
                TakeDamage(other.GetComponent<IActorTemplate>().SendDamage());
                Debug.Log("Player's health:" + health);
            }
            else if (health >= 100)
            {
                Die();
            }
        }
    }



}
