using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Create Actor",menuName ="Create Actor")]
public class SOActorModel : ScriptableObject
{
    //Give our actor a name
    public string actorName;

    //Create custom data types for our actors
    public enum ActorType
    {
       Player,
       SmallTeddyBear,
       BigTeddyBear,
       BossTeddyBear,
       Bullet
    }
    public ActorType actorType;

    //Default values for our player
    public string description;
    public int health;
    public float speed;
    public int hitPower;
    public int score;

    public GameObject actor;
    public GameObject actorBullets;
}
