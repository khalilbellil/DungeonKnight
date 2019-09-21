using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eUnitState { ATTACK, MOVE, DODGE, IDLE, ATTACKKSLIME }

public class Enemy : BaseUnit
{
    private float time = 0.05f;
    public float interpolationPeriod = 0.05f;
    public int Range;
    public Transform target;

    public Vector2 Target;

	//----Krina is Testing stuff----//
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("gotcha");
		HealthBar.health -= 10f;
	}
    public StateMachine stateM;
    public Grid grid;

	//-----------------------------//

	public int GetRange( )
    {
        return Range;
    }


    override public void UnitUpdate(float dt, Vector2 dir)
    {
        stateM.Update();
        base.UnitUpdate(dt, dir);
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
		Destroy(gameObject);
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

    public void LaunchSlime()
    {

        int[,] v = new int[,] { { -2, 0 }, { -2, 2 }, { 0, 2 }, { 2, 2 }, { 2, 0 }, { 2, -2 }, { 0, -2 }, { -2, -2 } };

        for (int i = 0; i < 8; i++)
        {
            Vector2 gridLocToCheck = (Vector2)this.transform.position;

            gridLocToCheck.x += v[i, 0];
            gridLocToCheck.y += v[i, 1];

            YeetSlime yS = GameObject.Instantiate(Resources.Load<YeetSlime>(PrefabsDir.slimeDir)).GetComponent<YeetSlime>();
            yS.transform.position = gridLocToCheck;
            yS.Init();
            yS.Launched(gridLocToCheck);
            EnemyManager.Instance.enemiesAlive.Add(yS);
        }

    }

    public void Dodge()
    {

        rb.AddForce((PlayerManager.Instance.player.transform.position - this.transform.position).normalized * 5, ForceMode2D.Impulse);
    }

    public void Attack()
    {
        UseWeapon((PlayerManager.Instance.player.transform.position - this.transform.position).normalized);
    }

    public void Move(Transform goal)
    {
        //return;
        time += Time.fixedDeltaTime;
        if (goal != null)
        {
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
                if (grid.GetPath().Count > 0)
                {
                    Vector2 dir = (grid.GetPath()[grid.GetPath().Count - 1].position - (Vector2)this.transform.position).normalized;
                    UpdateMovement(dir);
                }
                /*
                else
                {
                    UpdateMovement(new Vector2());
                }
                */
            }
        }
        else
        {
            UpdateMovement(new Vector2());
        }
        
    }
}


