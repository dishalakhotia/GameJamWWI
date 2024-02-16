using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Page", menuName = "Page Attributes", order = 51)]
public class PageAttributes : ScriptableObject
{
    public GameObject vfxPrefab;
    public int damage;
    public enum MotionPattern { Straight, Curve, Zigzag }
    public MotionPattern motionPattern;
}
