using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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

    //RigidBody variable to manage our physics
    Rigidbody rigidBody;

    [SerializeField, Range(1.0f,20.0f)]
    float jumpFactor = 20.0f;

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

    [SerializeField]
    ParticleSystem walkingParticles;

    void Start()
    {
        _Player = GameObject.Find("_Player");
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.State == GameState.Play)
        {
            //Updating the player's global position variable
            UpdatePlayersPosition();    

            //Creating the Move function
            Move();

            //Create the Attack function
            Attack();

            //Jump here
            Jump();
        }
    }

    void UpdatePlayersPosition()
    {
        GameManager.playerPosition = transform.position;
    }

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Forward/Backwards movement
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        //Left/Right movement
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        ControlParticles();
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
        GameManager.playerHealth += incomingDamage;
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

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Enemy"))
        {
            if (health < 100)
            {
                TakeDamage(otherCollider.GetComponent<IActorTemplate>().SendDamage());
                LevelUI.onLifeUpdate?.Invoke();
            }
            else
            {
                LevelUI.onLifeUpdate?.Invoke();
                Die();
            }
        }
    }

    void ControlParticles()
    {
        if (horizontalInput == 0 && verticalInput == 0) walkingParticles.Stop();// If we are idle Stop the particle system
        else if (!walkingParticles.isPlaying) walkingParticles.Play();//If we are moving Start the particle system
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("I am meant to be jumping!");
            if (rigidBody != null)
            {
               Debug.Log("We do have a rigid body!");
               rigidBody.AddForce(Vector3.up * jumpFactor, ForceMode.Impulse);
            }
        }
    }
}
