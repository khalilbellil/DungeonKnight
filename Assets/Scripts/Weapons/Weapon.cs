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
    protected int layerToHit;
    protected bool attackAvailable;
    protected float currentCdTimer;
    #endregion

    virtual public void Init(string hitableLayer)
    {
        currentCdTimer = 0;
        layerToHit = LayerMask.NameToLayer(hitableLayer);
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


    virtual public void Attack(Vector2 dir, Vector2 casterLocation, float dt)
    {
    }



}
