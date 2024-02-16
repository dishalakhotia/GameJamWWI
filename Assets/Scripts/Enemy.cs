using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;


    private EnemySpawner spawner;

    private float countdown = 5f;

    private void Start()
    {
        spawner = GetComponentInParent<EnemySpawner>();
    }

    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        //countdown -= Time.deltaTime;

        //if(countdown <= 0)
        //{
        //    Destroy(gameObject);

            
        //}
    }
}
