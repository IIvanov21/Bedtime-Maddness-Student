using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTeddyBear : MonoBehaviour, IActorTemplate
{
    //Default values
    float speed;
    int health;
    int hitPower;
    int score;

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        score= actorModel.score;
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
                GameManager.Instance.ScoreSystem();
                Die();

            }
        }
    }
}
