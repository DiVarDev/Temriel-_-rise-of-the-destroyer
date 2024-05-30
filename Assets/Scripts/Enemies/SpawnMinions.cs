using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinions : MonoBehaviour
{
    // Variables
    [Header("Minions Prefabs")]
    public GameObject lowRankEnemyPrefab;
    public GameObject mediumRankEnemyPrefab;
    [Header("Spawn Settings")]
    public GameObject spawn;
    public GameObject spawn1;
    public GameObject spawn2;
    public int maxSpawnCount = 1;
    public int spawnCount = 0;
    public float spawnCooldownTime = 5.0f;
    public float spawnTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCount <= maxSpawnCount)
        {
            StartCoroutine(SpawnCountdown());
            spawnCount++;
        }
        
    }

    // Functions
    public GameObject GetRandomPrefab()
    {
        GameObject prefab;
        System.Random rng = new System.Random();
        int k = rng.Next(1);
        switch (k)
        {
            case 0:
                prefab = lowRankEnemyPrefab;
                break;
            case 1:
                prefab = mediumRankEnemyPrefab;
                break;
            default:
                prefab = lowRankEnemyPrefab;
                break;
        }
        return prefab;
    }

    public void SpawningMinion()
    {
        // Instanciating the pellet
        Instantiate(GetRandomPrefab(), spawn.transform.position, Quaternion.identity);
        Instantiate(GetRandomPrefab(), spawn1.transform.position, Quaternion.identity);
        Instantiate(GetRandomPrefab(), spawn2.transform.position, Quaternion.identity);
    }

    // Coroutines
    public IEnumerator SpawnCountdown()
    {
        spawnTimer = spawnCooldownTime;
        while (spawnTimer > 0)
        {
            yield return new WaitForSeconds(1f);
            spawnTimer--;
        }
        SpawningMinion();
    }
}
