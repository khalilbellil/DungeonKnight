using UnityEngine;


public class Player : BaseUnit
{
    
    override public void Init()
    {
        Debug.Log("player init");
    }

    override public void UnitUpdate()
    {
        Debug.Log("player update");
    }

    override public void UnitFixedUpdate()
    {
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

}
