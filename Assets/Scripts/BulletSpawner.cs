using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRate = 1f;
    public int bulletsPerGroup = 5;
    public float groupInterval = 2f;
    // New variables for pattern control
    public float spreadAngle = 45f; // Angle between bullets in a spread pattern
    public int pattern = 0; // 0: Straight, 1: Spread, 2: Circular
    public Transform[] pathPoints;
    private int currentPointIndex = 0;
    public float moveSpeed = 5f;
    public int bulletsPerShot = 3;
    public float successionInterval = 0.2f;

    void Start()
    {
        StartCoroutine(SpawnBulletss());
    }
    void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (pathPoints.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, pathPoints[currentPointIndex].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= pathPoints.Length)
            {
                currentPointIndex = 0; // Loop back to the start of the path
            }
        }
    }

    IEnumerator SpawnBulletss()
    {
        while (true)
        {
            switch (pattern)
            {
                case 0: // Straight pattern
                    SpawnStraight();
                    break;
                case 1: // Spread pattern
                    SpawnSpread();
                    break;
                case 2: // Circular pattern
                    SpawnCircular();
                    break;
                case 3: // Succession pattern
                    yield return StartCoroutine(SpawnSuccession());
                    break;
                case 4: // Wave Pattern
                    yield return StartCoroutine(SpawnWave());
                    break;
                case 5: // Spiral Pattern
                    yield return StartCoroutine(SpawnSpiral());
                    break;
                case 6: // Burst Fire
                    yield return StartCoroutine(SpawnBurstFire());
                    break;
            }
            yield return new WaitForSeconds(groupInterval);
        }
    }

    void SpawnStraight()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }


    void SpawnSpread()
    {
        for (int i = 0; i < bulletsPerGroup; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, -spreadAngle / 2 + (spreadAngle / (bulletsPerGroup - 1)) * i, 0);
            Instantiate(bulletPrefab, transform.position, transform.rotation * rotation);
        }
    }

    void SpawnCircular()
    {
        float angleStep = 360f / bulletsPerGroup;
        for (int i = 0; i < bulletsPerGroup; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, angleStep * i, 0);
            Instantiate(bulletPrefab, transform.position, transform.rotation * rotation);
        }
    }
    IEnumerator SpawnSuccession()
    {
        for (int group = 0; group < bulletsPerGroup; group++)
        {
            for (int shot = 0; shot < bulletsPerShot; shot++)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                yield return new WaitForSeconds(successionInterval);
            }
            // Wait for the groupInterval before starting the next group of successions
            if (group < bulletsPerGroup - 1) // Prevent an extra wait at the end
            {
                yield return new WaitForSeconds(groupInterval);
            }
        }


    }

    IEnumerator SpawnWave()
    {
        float waveAngle = 0;
        for (int i = 0; i < bulletsPerGroup; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, Mathf.Sin(waveAngle) * spreadAngle, 0);
            Instantiate(bulletPrefab, transform.position, transform.rotation * rotation);
            waveAngle += Mathf.PI / bulletsPerGroup;
            yield return new WaitForSeconds(successionInterval);
        }
    }

    IEnumerator SpawnSpiral()
    {
        float spiralAngle = 0;
        for (int i = 0; i < bulletsPerGroup * bulletsPerShot; i++) // Increase count for longer spirals
        {
            Quaternion rotation = Quaternion.Euler(0, spiralAngle, 0);
            Instantiate(bulletPrefab, transform.position, transform.rotation * rotation);
            spiralAngle += 20; // Adjust for tighter or looser spirals
            yield return new WaitForSeconds(successionInterval);
        }
    }

    IEnumerator SpawnBurstFire()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
            for (int j = 0; j < bulletsPerGroup; j++)
            {
                // Calculate spread angle for each bullet in the burst
                Quaternion rotation = Quaternion.Euler(0, -spreadAngle / 2 + (spreadAngle / (bulletsPerGroup - 1)) * j, 0);
                Instantiate(bulletPrefab, transform.position, transform.rotation * rotation);
            }
            yield return new WaitForSeconds(successionInterval); // Pause between each burst
        }
    }
}
