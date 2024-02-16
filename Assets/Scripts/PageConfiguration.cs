using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PageConfiguration", menuName = "ScriptableObjects/PageConfiguration", order = 1)]
public class PageConfiguration : ScriptableObject
{
    public PageType[] pagesForThisLevel;
}