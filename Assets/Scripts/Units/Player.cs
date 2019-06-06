using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : BaseUnit
{
    
    override public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
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
        isAlive = false;
    }

    public void MovementAnimations()
    {
        Debug.Log("player animation");
    }

}
