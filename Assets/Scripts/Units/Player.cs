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
            useWeapon(input.dirPressed);

        if(input.interactPressed)
            Interact();

        base.UnitUpdate();
    }

    public void PlayerFixedUpdate(InputManager.InputPkg input)
    {
        if (input.jumpPressed)
            UseDash(input.dirPressed);

        UpdateMovement(input.dirPressed);

        base.UnitFixedUpdate();


        Debug.Log("player fixedupdate");
    }

    override public void death()
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

}
