using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseUnit
{
	//----Krina is Testing stuff----//
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("gotcha");
		HealthBar.health -= 10f;
	}

	//-----------------------------//

	public int GetRange( )
    {
        return 30;
    }

    override public void death()
    {
        Debug.Log("enemy isDead");
        DropItem();
        isAlive = false;
    }

    override public void MovementAnimations()
    {
        Debug.Log("enemy animation");
    }

    public void MoveTo(Vector2 goalPos)
    {
        Vector2 dir = (goalPos - (Vector2)transform.position).normalized;
        Debug.Log("enemy isMoving");
        UpdateMovement(dir);
    }

    //public void CalculatedD

    public void DropItem()
    {
        Debug.Log("enemy Droped item");
    }

    public void Dodge()
    {

    }

    public void Attack()
    {
        //useWeapon();
    }

    public void Move()
    {
        //MoveTo();
    }
}


