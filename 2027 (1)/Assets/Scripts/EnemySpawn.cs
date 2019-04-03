using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public int numberOfEnemies = 0;
    public GameObject enemyPrefab;
    private Vector3 randomPosition;
    private float spawnTime = 10;
    
    private int x;
    private int y;
    
	void Start () {
        randomPosition = transform.position;
	}
	
	void Update () {

        spawnTime -= Time.deltaTime;

        if (spawnTime < 0 && numberOfEnemies < 3)
        {
            SpawnEnemy();
            spawnTime = 10;
        }
	}

    public void SpawnEnemy()
    {

        x = Random.Range(-10, 10);
        y = Random.Range(-10, 10);

        randomPosition += new Vector3(x, y, y);
        Instantiate(enemyPrefab, randomPosition, transform.rotation);
        numberOfEnemies++;
    }
}
