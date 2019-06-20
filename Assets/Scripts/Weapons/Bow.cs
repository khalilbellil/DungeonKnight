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
    public static readonly float maxDrawingTime = 3;


    #region Bow Stats:
    [Header("Bow Specific:")]
    [SerializeField] public float arrowSpeed;
    [SerializeField] private float speedModifier;
    [SerializeField] private ArrowType type;
    [SerializeField] private Arrow arrowPrefab;
    #endregion

    private float power;
    private float timerStart;
    private float timerEnd;
    private float timeDrawingBow;
    private bool chargingAtk;

    public static Arrow arrowGo;

    BowPkg arrowStats;

    override public void Init(LayerMask hitableLayer, BaseUnit _owner)
    {
        arrowStats = new BowPkg();

        type = ArrowType.DEFAULT;
        dammage = 15;
        arrowSpeed = 35;        //to test
       // maxDrawingTime = 3;
        arrowStats.arrowSpeed = this.arrowSpeed;
        this.speedModifier = 1;
        arrowStats.speedModifier = this.speedModifier;
        arrowStats.hitBoxSize = this.hitBoxSize;
        arrowStats.layerToHit = this.layerToHit;
        arrowStats.owner = _owner;

        arrowGo = Resources.Load<Arrow>(PrefabsDir.arrowWeaponDir);
        arrowStats.arrowGo = arrowGo;

        animTrigger = "UseBow";
        

        base.Init(hitableLayer, _owner);


    }

    override public void WeaponUpdate(float dt, bool isHolding, Vector2 dir, Vector2 casterLocation)
    {
        base.WeaponUpdate(dt, isHolding, dir, casterLocation);
        if (isHolding && !chargingAtk && attackAvailable)
        {
            attackAvailable = false;
            Debug.Log("Attack not available");
            timerStart = Time.time;
            chargingAtk = true;
            owner.UseAttackAnim("UseBow");
        }

        if(!isHolding && chargingAtk && owner.arrowCount > 0)
        {

            chargingAtk = false;
            timerEnd = Time.time;
            timeDrawingBow = timerEnd - timerStart;

            power = Mathf.Clamp((timeDrawingBow / maxDrawingTime), 0.1f, 1);
            arrowStats.dammage = this.dammage * power;

            Attack(dir, casterLocation);

            owner.arrowCount--;

            owner.UseAttackAnim("ReleaseBow");

            ProjectileManager.Instance.CreateArrow(arrowStats);
        }

    }

    override public void WeaponFixedUpdate()
    {
        
    }

    public override void Attack(Vector2 dir, Vector2 casterLocation)        //this only sets the direction of the arrow
    {
        arrowStats.dir = dir.normalized;
        //Debug.Log("Dir: " + arrowStats.dir);
        base.Attack(dir, casterLocation);
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


