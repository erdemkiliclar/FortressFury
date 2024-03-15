using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float radius;
    public float minSpawnInterval;
    public float maxSpawnInterval;

    void Start()
    {

        
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            float angle = Random.Range(0f, Mathf.PI * 2);
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], transform.position + pos, Quaternion.identity);

            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
