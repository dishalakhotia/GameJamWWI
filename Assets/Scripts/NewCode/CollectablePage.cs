using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablePage : MonoBehaviour
{
    public int weaponIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("weapon ACQ" + weaponIndex);

            LevelManager.instance.SetWeaponIndex(weaponIndex);
            Destroy(gameObject, 1f);

        }
        
    }
}
