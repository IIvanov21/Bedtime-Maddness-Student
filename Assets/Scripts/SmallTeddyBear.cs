using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTeddyBear : MonoBehaviour, IActorTemplate
{
    //Default values
    float speed;
    int health;
    int hitPower;

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        
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
                Die();
            }
        }
    }
}
