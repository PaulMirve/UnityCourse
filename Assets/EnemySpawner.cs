using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float secondsBetweenSpawns;
    private float secondsSinceLastSpawn;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastSpawn = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        secondsSinceLastSpawn += Time.fixedDeltaTime;
        if (secondsSinceLastSpawn >= secondsBetweenSpawns)
        {
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            secondsSinceLastSpawn = 0;
        }
    }
}
