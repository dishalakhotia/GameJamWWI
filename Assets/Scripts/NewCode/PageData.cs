using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapons/Weapon Data")]
public class PageData : ScriptableObject
{
    public int damage;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public GameObject vfxPrefab;
    public ParticleSystem particleSystemPrefab;
    public RawImage uiRawImageTexture;
}
