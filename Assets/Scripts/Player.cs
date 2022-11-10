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
    }

    void FixedUpdate()
    {

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

   

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health-=incomingDamage;
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


}
