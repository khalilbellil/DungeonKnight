using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ArrowType
{
    DEFAULT,
    FIRE,
    EXPLOSIVE
}

public class Bow : Weapon
{
    #region Bow Stats:
    [Header("Bow Specific:")]
    [SerializeField] public float arrowSpeed;
    [SerializeField] private int nbArrow;
    [SerializeField] private int maxNbArrow;
    [SerializeField] private ArrowType type;
    #endregion

    private void Init()
    {
        nbArrow = maxNbArrow;
        type = ArrowType.DEFAULT;
        arrowSpeed = 15;        //to test
    }
}
