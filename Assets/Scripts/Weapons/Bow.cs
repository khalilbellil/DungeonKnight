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
    [SerializeField] private float speedModifier;
    [SerializeField] private ArrowType type;
    [SerializeField] private float maxDrawingTime;
    [SerializeField] private Arrow arrowPrefab;
    #endregion

    private float power;
    private float timerStart;
    private float timerEnd;
    private float timeDrawingBow;
    private bool isHolding;

    private Arrow arrowGo;

    BowPkg arrowStats;

    override public void Init(LayerMask hitableLayer, BaseUnit _owner)
    {
        arrowStats = new BowPkg();

        type = ArrowType.DEFAULT;

        arrowSpeed = 5;        //to test
        arrowStats.arrowSpeed = this.arrowSpeed;
        this.speedModifier = 1;
        arrowStats.speedModifier = this.speedModifier;
        arrowStats.hitBoxSize = this.hitBoxSize;
        arrowStats.layerToHit = this.layerToHit;
        arrowStats.owner = this.owner;

        arrowGo = Resources.Load<Arrow>("Prefabs/Weapons/Arrow");
        arrowStats.arrowGo = this.arrowGo;
        isHolding = false;
        base.Init(hitableLayer, _owner);


    }

    override public void WeaponUpdate(float dt)
    {
        if (InputManager.Instance.inputPressed.leftMouseButtonPressed && !isHolding)
        {
            isHolding = true;
            timerStart = Time.time;
        }

        if(InputManager.Instance.inputPressed.leftMouseButtonReleased && isHolding)
        {
            isHolding = false;
            timerEnd = Time.time;

            AddPower();

            ProjectileManager.Instance.CreateArrow(arrowStats);
        }
    }

    override public void WeaponFixedUpdate()
    {
        
    }

    public override void Attack(Vector2 dir, Vector2 casterLocation)
    {
//        arrowList[arrowList.Count].Init(dir, );

        base.Attack(dir, casterLocation);
    }

    private void AddPower()
    {
        power = Mathf.Clamp01(timeDrawingBow / maxDrawingTime);
        dammage *= power;
        arrowStats.dammage = this.dammage;
    }

    public class BowPkg
    {
        public float dammage;
        public float arrowSpeed;
        public float speedModifier;
        public Vector2 hitBoxSize;
        public LayerMask layerToHit;
        public BaseUnit owner;
        public Vector2 dir;
        public Arrow arrowGo;
    }
}


