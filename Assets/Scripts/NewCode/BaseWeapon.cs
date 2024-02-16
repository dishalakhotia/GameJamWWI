using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    protected PageData _PageData;

    public void Initialize(PageData data)
    {
        _PageData = data;
    }

    public abstract void Fire(Vector3 direction);
}
