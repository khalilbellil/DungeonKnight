using UnityEngine;

public class Player : BaseUnit
{

	public int coins;


    override public void Init()
    {
        base.Init();
        //Debug.Log("player init");

        foreach(Weapon weapon in weaponList)
        {
            weapon.Init(hitableLayer, this);
        }
        maxArrowCount = 20;

        isHolding = false;
    }

    public void PlayerUpdate(InputManager.InputPkg input, float dt)
    {

        isHolding = input.leftMouseButtonHeld;

        if(input.interactPressed)
            Interact();

        if (input.switchWeaponPressed)         
            SwitchWeapon();

        base.UnitUpdate(dt, input.aimingDirection);
        MovementAnimations();

    }

    public void PlayerFixedUpdate(InputManager.InputPkg input, float dt)
    {
        if (input.jumpPressed && dashAvailable)
            isDashing = true;

        UpdateMovement(input.dirPressed);
        //Debug.Log(transform.GetComponent<Rigidbody2D>().velocity);

        base.UnitFixedUpdate();
    }

    override public void Death()
    {
		gameObject.SetActive(false);
		//GameObject.FindObjectOfType<MainEntry>().GoToNextFlow(CurrentState.Menu);//Restart the current Scene/Flow.
		PlayerManager.Instance.gameFlow.PlayerDied();
		Debug.Log("player isDead");
    }

	override public void MovementAnimations()
    {
        //Debug.Log("player animation");
        anim.SetFloat("RunSpeed", rb.velocity.magnitude / speed);

    }

    public void Interact()
    {
        Debug.Log("Interact");
    }

    public void UseActive()
    {

    }

    public void SwitchWeapon()
    {
        if (weaponList != null)
        {
            weaponList[activeWeaponIndex].gameObject.SetActive(false);  //turns off the weapon we are unequiping

            activeWeaponIndex++;


            if(activeWeaponIndex + 1 > weaponList.Length)
            {
                activeWeaponIndex = 0;
            }

            Debug.Log(weaponList[activeWeaponIndex].transform.name + " equipped");
            weaponList[activeWeaponIndex].gameObject.SetActive(true);   //turns on the weapon using now
        }

    }

}
