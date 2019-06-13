using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ 
    #region Weapon Stats
    [Header("Weapon Stats:")]
    [SerializeField] public int dammage;
    [SerializeField] public Vector2 hitBoxSize;
    [SerializeField] public float cdForNextAtk;
    protected LayerMask layerToHit;
    protected bool attackAvailable;
    protected float currentCdTimer;
    #endregion

    virtual public void Init(LayerMask hitableLayer)
    {
        currentCdTimer = 0;
        layerToHit = hitableLayer;
        attackAvailable = true;
    }

    virtual public void WeaponUpdate(float dt)
    {
        if (!attackAvailable)
        {
            currentCdTimer += dt;
            if (currentCdTimer >= cdForNextAtk)
            {
                attackAvailable = true;
                currentCdTimer = 0;
            }
        }
    }

    virtual public void WeaponFixedUpdate()
    {

    }


    virtual public void Attack(Vector2 dir, Vector2 casterLocation)
    {
    }



}
