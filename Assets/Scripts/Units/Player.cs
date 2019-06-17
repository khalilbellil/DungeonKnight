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
    }

    public void PlayerUpdate(InputManager.InputPkg input, float dt)
    {

        if(input.leftMouseButtonPressed)
            UseWeapon(input.aimingDirection);

        if(input.interactPressed)
            Interact();

        if (input.switchWeaponPressed)         
            SwitchWeapon();

        weaponList[activeWeaponIndex].WeaponUpdate(dt);
        MovementAnimations();
        base.UnitUpdate();
    }

    public void PlayerFixedUpdate(InputManager.InputPkg input, float dt)
    {
        if (input.jumpPressed)
            UseDash(input.dirPressed);

        UpdateMovement(input.dirPressed);

        base.UnitFixedUpdate();

		CharacterRotation(input.deltaMouse);
    }

    override public void Death()
    {
		GameObject.FindObjectOfType<MainEntry>().GoToNextFlow(CurrentState.Menu);//Restart the current Scene/Flow.
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
