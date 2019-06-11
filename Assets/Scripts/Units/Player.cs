using UnityEngine;

public class Player : BaseUnit
{
 
    override public void Init()
    {
        Debug.Log("player init");
    }

    public void PlayerUpdate(InputManager.InputPkg input)
    {
        Debug.Log("player update");

        if(input.leftMouseButtonPressed)
            UseWeapon(input.dirPressed);

        if(input.interactPressed)
            Interact();

        if (input.switchWeaponPressed)         
            SwitchWeapon();

        base.UnitUpdate();
    }

    public void PlayerFixedUpdate(InputManager.InputPkg input)
    {
        if (input.jumpPressed)
            UseDash(input.dirPressed);

        UpdateMovement(input.dirPressed);

        base.UnitFixedUpdate();

		CharacterRotation(input.deltaMouse);

        Debug.Log("player fixedupdate");
    }

    override public void Death()
    {
        Debug.Log("player isDead");
    }

	override public void MovementAnimations()
    {
        Debug.Log("player animation");
    }

    void Jump()
    {

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
       // weaponList[activeWeaponIndex].enabled = false;  //turns off the weapon we are unequiping
        if (activeWeaponIndex == 0)         /*When prefabs for the weapons are attached to the player, just hide the one not used*/
        {
            activeWeaponIndex = 1;
            Debug.Log("Bow equipped");
        }
        else
        {
            activeWeaponIndex = 0;
            Debug.Log("Sword equipped");
        }
        //weaponList[activeWeaponIndex].enabled = true;   //turns on the weapon using now
    }

}
