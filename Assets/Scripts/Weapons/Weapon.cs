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
    #endregion

    virtual public void Init()
    {

    }

    virtual public void WeaponUpdate()
    {

    }

    virtual public void WeaponFixedUpdate()
    {

    }


    virtual public void Attack(Vector2 dir)
    {
        Debug.Log("Default attack");
    }



}
