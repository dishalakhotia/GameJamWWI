using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float waveCountdown;

    [SerializeField] private List <GameObject> spawnPoints;

    public Wave[] waves;

    private int waveIndex = 0;

    private bool readyToCountDown;

    private void Start()
    {
        readyToCountDown = true;

        for(int i=0; i<waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }

    void Update()
    {
        waveCountdown -= Time.deltaTime;   

        if (waveCountdown <= 0)
        {
            readyToCountDown = false;
            waveCountdown = waves[waveIndex].waveInterval;
            StartCoroutine(SpawnWave());
        }

    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[waveIndex].enemies.Length; i++)
        {
            for (int J = 0; J < spawnPoints.Count; J++)
            {
                Enemy enemy = Instantiate(waves[waveIndex].enemies[i], spawnPoints[J].transform);
                enemy.transform.SetParent(spawnPoints[J].transform);
            }



            yield return new WaitForSeconds(waves[waveIndex].enemyInterval);
        }

    }

    [System.Serializable]

    public class Wave
    {
        public Enemy[] enemies;
        public float enemyInterval;
        public float waveInterval;

        [HideInInspector] public int enemiesLeft;
    }
}