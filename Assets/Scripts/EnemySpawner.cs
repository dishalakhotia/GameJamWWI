using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float waveCountdown;

    [SerializeField] private List <GameObject> spawnPoints;

    public Wave[] waves;

    [HideInInspector] public int waveIndex = 0;

    private bool readyToCountDown;

    public Transform wayPoint1, wayPoint2;

    bool Spawing = false;
    bool wavesComplete;

    private void Start()
    {
        wavesComplete = false;
        readyToCountDown = true;

        for(int i=0; i<waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }

    void Update()
    { if(waveIndex >= waves.Length)
        {
            Debug.Log("Congrats you win!!");
            wavesComplete = true;
            return;

        }
        waveCountdown -= Time.deltaTime;   

        if (waveCountdown <= 0 && !Spawing)
        {
            readyToCountDown = false;
            waveCountdown = waves[waveIndex].waveInterval;
            StartCoroutine(SpawnWave());
            Spawing = true;
        }

        if (waves[waveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            waveIndex++;
        }
    }

    IEnumerator SpawnWave()
    {
        if (waveIndex < waves.Length)
        {
            for (int i = 0; i < waves[waveIndex].enemies.Length; i++)
            {
                for (int J = 0; J < spawnPoints.Count; J++)
                {
                    EnemyAIController enemy = Instantiate(waves[waveIndex].enemies[i], spawnPoints[J].transform.position, spawnPoints[J].transform.rotation);
                    enemy.waypoints[0] = wayPoint1;
                    enemy.waypoints[1] = wayPoint2;
                }



                yield return new WaitForSeconds(waves[waveIndex].enemyInterval);
            }
        }
    }

    [System.Serializable]

    public class Wave
    {
        public EnemyAIController[] enemies;
        public float enemyInterval;
        public float waveInterval;

        [HideInInspector] public int enemiesLeft;
    }
}