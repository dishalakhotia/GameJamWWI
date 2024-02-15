using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewBulletPattern", menuName = "BulletPattern", order = 0)]
public class BulletPattern : ScriptableObject
{
    public float bulletSpeed = 10f;
    public int bulletsPerGroup = 5;
    public float intervalBetweenBullets = 0.1f;
    public float intervalBetweenGroups = 1f;
    // Additional properties like path for moving spawners can be added here
}
