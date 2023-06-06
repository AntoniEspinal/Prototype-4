using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public GameObject hardenemyPrefab;
    public GameObject bossEnemy;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public int bossWaveNumber = 5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnBossWave(bossWaveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
        if (waveNumber > 4)
        {
            bossWaveNumber++;
            SpawnBossWave(bossWaveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        for(int i = 3; i > enemiesToSpawn; i++)
        {
            Instantiate(hardenemyPrefab, GenerateSpawnPosition(), hardenemyPrefab.transform.rotation);
        }
    }

    void SpawnBossWave(int bossTimer)
    {
        for(int i = 0; i < bossTimer; i++)
        {
            Instantiate(bossEnemy, GenerateSpawnPosition(), bossEnemy.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
