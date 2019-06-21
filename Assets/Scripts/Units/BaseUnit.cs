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
    protected bool isDashing;
    public int activeWeaponIndex;
    public int maxArrowCount;
    public int arrowCount;
    protected bool isHolding;
    private float dashTime;     //time for how long we want the dash to last
    private float dashCDTime;   //cooldown after once the dash is finished
    protected bool dashAvailable;
    //protected float timeOfLastDash;
    //public float dashCD;
    //protected bool dashAvailable { get { return (Time.time - timeOfLastDash) > dashCD; } }
    private TrailRenderer tr;


    #endregion

    #region Unit Stats
    [Header("Unit Stats:")]

    [SerializeField] public float health;
	[SerializeField] public float maxHealth;
	[SerializeField] protected int speed;
    [SerializeField] private float dashingSpeed;
    [SerializeField] private float dashTimer;       //set the time of the dash
    [SerializeField] private float dashCDTimer;     //set the time for after the dash
    [SerializeField] private double critChance;
    [SerializeField] public double critMultipier;
    [SerializeField] protected LayerMask hitableLayer;
    [HideInInspector] public float speedMultiplier = 1;
    #endregion

    [HideInInspector] public Rigidbody2D rb;
    protected Animator anim;
    //public Transform target;
    protected Vector3 scale;

    // // //

    virtual public void Init()
    {
        //speed = 10;
        isAlive = true;
        if(weaponList != null)
            activeWeaponIndex = 0;
       
        rb = GetComponent<Rigidbody2D>();
        // Debug.Log("basic init");
        tr = GetComponent<TrailRenderer>();
        anim = GetComponent<Animator>();
        foreach (Weapon weapon in weaponList)
        {
            weapon.Init(hitableLayer, this);
        }
        
        isHolding = false;
        dashAvailable = true;
        dashTime = dashTimer;

        scale = transform.localScale;
        scale.x *= -1;
    }
    
    virtual public void UnitUpdate(float dt, Vector2 dir)
    {
        if (weaponList.Length > 0)
        {
            if (!dashAvailable)
            {
                dashCDTime -= Time.deltaTime;
                if (dashCDTime <= 0)
                {
                    dashCDTime = dashCDTimer;
                    dashAvailable = true;
                }
            }

            weaponList[activeWeaponIndex].WeaponUpdate(dt, isHolding, dir, this.transform.position);

            Flip(dir);
        }
        
    }

    virtual public void UnitFixedUpdate()
    {
        //Debug.Log("basic fixedupdate");
    }

	virtual public void Death()
    {
        Debug.Log("basic isDead");
        isAlive = false;
        anim.SetTrigger("isDead");
    }

    virtual public void MovementAnimations()
    {
        //Debug.Log("basic animation");
    }

    private void Flip(Vector2 dir)
    {
        if (dir.x < 0)
        {
            scale.x = 1;
            transform.localScale = scale;
        }
        else
        {
            scale.x = -1;
            transform.localScale = scale;
        }

    }

    public void UseWeapon(Vector2 dir) {

        weaponList[activeWeaponIndex].Attack(dir, this.transform.position);
    }

    virtual public void UpdateMovement(Vector2 dir)
    {
        if (!isDashing)
        {
            rb.velocity = dir * speed * speedMultiplier;
            anim.SetFloat("RunSpeed", rb.velocity.magnitude / speed);
        }
        else
            DashUpdate(dir);
    }

    public void ChangeSpeedMultiplier(float _speedMult)
    {
        speedMultiplier = _speedMult;

    }

    public void UseDash()
    {
        if (!isDashing)
        {
            if (tr != null)
            {
                tr.enabled = true;
                isDashing = true;
                tr.Clear();
                anim.SetBool("Dashing", true);
            }
            
        }
        //Debug.Log("Dash");
    }

    protected void DashUpdate(Vector2 dir)
    {
        dashTime -= Time.deltaTime;
        if (dashTime <= 0)
        {
            isDashing = false;
            dashTime = dashTimer;
            tr.enabled = false;
            dashAvailable = false;
            anim.SetBool("Dashing", false);
        }
        rb.velocity = dir * dashingSpeed;
    }
     
    public virtual void TakeDamage(float dmg)
    {
		if (isAlive && !isDashing)      //will only take damage if he is alive and is not invincible from dashing
		{
			health -= dmg;
			if (health <= 0) {
				isAlive = false;
				Death();
			}
			Debug.Log("basic takedamage " + dmg + " Remaining health : " + health + " Name : " + name);
		}
    }

    public void UseAttackAnim(string triggerName)
    {
        anim.SetTrigger(triggerName);
    }


}
