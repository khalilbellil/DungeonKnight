using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseUnit
{

    public int AstarTimer = 0;

	//----Krina is Testing stuff----//
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("gotcha");
		HealthBar.health -= 10f;
	}
    public StateMachine stateM;
    public Grid grid;

	//-----------------------------//

	public int GetRange( )
    {
        return 3;
    }

    override public void Death()
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
        Debug.Log("enemy Attacked");
        //useWeapon();
    }

    public void Move(Transform goal)
    {
        //return;
        grid.Astar(this.transform, goal);
        if (grid.GetPath().Count == 0)
        {

            UpdateMovement(new Vector2());
        }
        else
        {
            Vector2 dir = (grid.GetPath()[grid.GetPath().Count - 1].position - (Vector2)this.transform.position/*(Vector2)transform.position*/).normalized;
            UpdateMovement(dir);
        }
        
        
    }
}


