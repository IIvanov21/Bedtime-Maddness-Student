using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour,IActorTemplate
{
    //Normal actor values
    GameObject actor;
    int health;
    int hitPower;
    float speed;

    //Import for custom actor properties
    [SerializeField]
    SOActorModel bulletModel;

    public void ActorStats(SOActorModel actorModel)
    {
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        speed = actorModel.speed;
        actor = actorModel.actor;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    void Awake()
    {
        ActorStats(bulletModel);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (health >= 1) health -= collider.GetComponent<IActorTemplate>().SendDamage();
            if (health <= 0) Die();
        }
    }

    //Make sure to replace this method as it will cause issues
    void OnBecameInvisible()
    {
        Die();
    }
}
