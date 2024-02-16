using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public GameObject ImpactPrefab;
    public List<GameObject> trails;
    //protected List<IDamage> Damageable = new List<IDamage>();
    private Rigidbody rb;
    public Vector3 offset;
    protected Coroutine playerAttackCoroutine;
    public int damage; // Damage the bullet does to the player
    // public delegate void AttackEvent(IDamage Target);
    //public AttackEvent OnAttack;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        rb.useGravity = false; // Turn off gravity for the bullet
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // Improve collision detection for fast-moving objects
        // Prevent bullet self-collision, assuming bullets are on a specific layer
        Physics.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed != 0 && rb != null)
        {
            rb.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Debug.Log("hit enemy for" + " " + damage);
           
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            Debug.Log("enemyHit");
            
        }

        speed = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point + offset;

        if (ImpactPrefab != null)
        {
            var impactVFX = Instantiate(ImpactPrefab, pos, rot) as GameObject;
            Destroy(impactVFX, 5);
        }

        if (trails.Count > 0)
        {
            for (int i = 0; i < trails.Count; i++)
            {
                trails[i].transform.parent = null;
                var ps = trails[i].GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Stop();
                    Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                }
            }
        }


        Destroy(gameObject);
    }



    public void PlayerAttack()
    {
        Debug.Log("attacking");

        //IDamage closestDamageable = null;
        float closestDistance = float.MaxValue;
        /*for (int i = 0; i < Damageable.Count; i++)
        {
            Transform damagebleTransform = Damageable[i].GetTransform();
            float distance = Vector3.Distance(transform.position, damagebleTransform.position);

            if (distance < closestDistance)
            {
                Debug.Log("enemyAdded");
                closestDistance = distance;
                closestDamageable = Damageable[i];
            }
        }

        /*if (closestDamageable != null)
        {
            Debug.Log("attack initiated");
            OnAttack?.Invoke(closestDamageable);
            closestDamageable.TakeDamage(PlayerClass.Instance.baseAttackDamage);
            Debug.Log("Enemy Hit" + PlayerClass.Instance.baseAttackDamage);

        }

        closestDamageable = null;
        closestDistance = float.MaxValue;



        Damageable.RemoveAll(DisableDamageable);

        playerAttackCoroutine = null;
    }
   
       
    /*protected bool DisableDamageable(IDamage Damageable)
    {
        return Damageable != null && !Damageable.GetTransform().gameObject.activeSelf;
    }*/
    }
}

