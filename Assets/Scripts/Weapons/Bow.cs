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
    #region Sword Stats:
    [Header("Bow Specific:")]
    [SerializeField] private float arrowSpeed;
    [SerializeField] private int nbArrow;
    [SerializeField] private ArrowType type;
    #endregion


}
