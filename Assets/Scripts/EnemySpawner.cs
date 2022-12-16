using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    SOActorModel actorModel;//The enemy data container

    [SerializeField]
    [Tooltip("The amount of seconds between spawning enemies.")]
    float spawnRate;

    [SerializeField, Range(1, 10)]
    [Tooltip("The amount of enemies you can spawn.")]
    int quantity;

    GameObject _Enemies;

    private void Awake()
    {
        _Enemies = GameObject.Find("_Enemies");

        //Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for(int i=0;i<quantity;i++)
        {
            GameObject enemyObject = CreateEnemy();
            enemyObject.transform.SetParent(_Enemies.transform);
            //enemyObject.transform.position = transform.position;

            yield return new WaitForSeconds(spawnRate);
        }

        yield return null; 
    }

    GameObject CreateEnemy()
    {
        GameObject enemy = GameObject.Instantiate(actorModel.actor,transform.position,transform.rotation) as GameObject;

        enemy.GetComponent<IActorTemplate>().ActorStats(actorModel);
        enemy.name=actorModel.name;

        return enemy;
    }
}
