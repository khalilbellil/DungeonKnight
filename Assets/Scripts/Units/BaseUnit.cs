using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseUnit : MonoBehaviour
{
    //To add more weapons, increase the size of the weaponList in the unity, on the character's prefab
    //and pass it a prefab that is or inherits of Weapon class
    public Weapon[] weaponList;

    #region VARIABLES
    public bool isAlive;
    public int activeWeaponIndex;  //  0 = Sword, 1 = Bow (not implemented yet)
    public int maxArrowCount;
    public int arrowCount;
    #endregion

    #region Unit Stats
    [Header("Unit Stats:")]

    [SerializeField] public int health;
	[SerializeField] public int maxHealth;
	[SerializeField] protected int speed;
    [SerializeField] private double critChance;
    [SerializeField] private double critMultipier;
    [SerializeField] protected LayerMask hitableLayer;
    [HideInInspector] public float speedMultiplier = 1; 
    #endregion

    [HideInInspector] public Rigidbody2D rb;
    protected Animator anim;

    // // //

    virtual public void Init()
    {
        speed = 10;
        isAlive = true;
        if(weaponList != null)
            activeWeaponIndex = 0;
       
        rb = GetComponent<Rigidbody2D>();
        // Debug.Log("basic init");

        anim = GetComponent<Animator>();
        foreach (Weapon weapon in weaponList)
        {
            weapon.Init(hitableLayer, this);
        }
    }
    
    virtual public void UnitUpdate(float dt)
    {
        weaponList[activeWeaponIndex].WeaponUpdate(dt);
        //Debug.Log(Vector2.Distance(PlayerManager.Instance.player.transform.position, this.transform.position));
    }

    virtual public void UnitFixedUpdate()
    {
        //Debug.Log("basic fixedupdate");
    }

	virtual public void Death()
    {
        Debug.Log("basic isDead");
        isAlive = false;
    }

    virtual public void MovementAnimations()
    {
        Debug.Log("basic animation");
    }

    public void UseWeapon(Vector2 dir) {

        weaponList[activeWeaponIndex].Attack(dir, this.transform.position);
    }

    virtual public void UpdateMovement(Vector2 dir)
    {
        rb.velocity = dir * speed * speedMultiplier;
    }

    public void ChangeSpeedMultiplier(float _speedMult)
    {
        speedMultiplier = _speedMult;

    }

    public void UseDash(Vector2 dir)
    {
        Debug.Log("Dash");
    }
     
    public void TakeDamage(int dmg)
    {
		if (isAlive)
		{
			health -= dmg;
			if (health <= 0)
				isAlive = false;
			Debug.Log("basic takedamage " + dmg + " Remaining health : " + health + " Name : " + name);
		}
    }

    public void UseAttackAnim(string triggerName)
    {
        anim.SetTrigger(triggerName);
    }


}
