using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Variables
    private float useCdTime;
    #endregion

    #region Weapon Stats
    [Header("Weapon Stats:")]
    [SerializeField] public int dammage;
    [SerializeField] public Vector2 hitBoxSize;
    protected int layerToHit;

    #endregion

    virtual public void Init(string hitableLayer)
    {
        layerToHit = LayerMask.NameToLayer(hitableLayer);
    }

    virtual public void WeaponUpdate()
    {

    }

    virtual public void WeaponFixedUpdate()
    {

    }


    virtual public void Attack(Vector2 dir, Vector2 casterLocation)
    {

    }



}
