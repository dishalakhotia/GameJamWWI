using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Page", menuName = "Game/Page")]
public class PageScriptableObject : ScriptableObject
{
    public string pageName = "New Page";
    public string description = "Description here";
    public float attackSpeed = 1f;
    public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public GameObject vfxPrefab;
    public Sprite rawImage; // Using Sprite as it's more common for UI in Unity
    public int damage = 10;
    public float bulletSpeed = 30f; // Ensure this property is added
    public float bulletLifeTime = 5f;

    // Add any other properties you think might be necessary for your game's mechanics
}
