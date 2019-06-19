using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseUnit
{
    private float time = 0.05f;
    public float interpolationPeriod = 0.05f;
    public int Range;

    public Vector2 Target;

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
        return Range;
    }

	override public void UnitUpdate(float dt)
    {
        stateM.Update();
        base.UnitUpdate(dt);
    }

    override public void UnitFixedUpdate()
    {
        stateM.FixedUpdate();
    }

    override public void Death()
    {
		//Debug.Log("enemy isDead");
		base.Death();
		DropItem();
		EnemyManager.Instance.RemoveEnemy(this);
    }

    override public void MovementAnimations()
    {
        //Debug.Log("enemy animation");
    }

    public void MoveTo(Vector2 goalPos)
    {
        Vector2 dir = (goalPos - (Vector2)transform.position).normalized;
        //Debug.Log("enemy isMoving");
        UpdateMovement(dir);
    }

    public void DropItem()
    {
		Item.RandomItemSpawn(gameObject.transform.position);
		
        //Debug.Log("enemy Droped item");
    }

    public void Dodge()
    {

    }

    public void Attack()
    {
        UseWeapon((PlayerManager.Instance.player.transform.position - this.transform.position).normalized);
    }

    public void Move(Transform goal)
    {
        //return;
        time += Time.fixedDeltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            grid.Astar(this.transform, goal);
        }
        if (grid.GetPath() == null)
        {
            UpdateMovement(new Vector2());
        }
        else
        {
            Vector2 dir = (grid.GetPath()[grid.GetPath().Count - 1].position - (Vector2)this.transform.position).normalized;
            UpdateMovement(dir);
        }
    }
}


