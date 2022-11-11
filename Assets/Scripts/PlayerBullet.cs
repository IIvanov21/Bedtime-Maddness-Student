using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, IActorTemplate
{
    int health;
    int hitPower;
    float speed;

    GameObject actor;

    [SerializeField]
    SOActorModel bulletModel;

    void Awake()
    {
        ActorStats(bulletModel);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Die();
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void ActorStats(SOActorModel actorModel)
    {
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        speed = actorModel.speed;
        actor = actorModel.actor;
    }


}
