using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Bow.BowPkg arrowStats;
    private bool isTravelling;
    private float distanceToCheck;      //distance to check with raycast in front of the arrow 
    private Collider2D target;
    private Rigidbody2D rb;
    public  GameObject go;

    public void Init(Bow.BowPkg bowPkg)
    {

        arrowStats = bowPkg;
        go = arrowStats.arrowGo.gameObject;
        SpawnArrow();
        isTravelling = true;
        
        rb = go.GetComponent<Rigidbody2D>();


    }

    public void UpdateArrow(float dt)
    {
        if (isTravelling)
        {
            distanceToCheck = arrowStats.arrowSpeed * arrowStats.dir.magnitude * dt;
            Attack();

            Move();
        }
    }
    
    public void SpawnArrow()
    {
        Instantiate(go, arrowStats.owner.transform.position, Quaternion.identity);
        ProjectileManager.Instance.arrowList.Add(this);
        Debug.Log("Spawn Arrow");
    }

    public void Move()
    {
        rb.velocity = arrowStats.dir * arrowStats.arrowSpeed * arrowStats.speedModifier;
    }

    public void Attack()
    {

        target = Physics2D.Raycast(arrowStats.owner.transform.position, arrowStats.dir, distanceToCheck, arrowStats.layerToHit).collider;       //returns the collider of the RayCastHit2D from the layer given

        if (target != null)
        {
            target.GetComponent<BaseUnit>().TakeDamage(arrowStats.dammage);
            isTravelling = false;


            Debug.Log("Hit a target ! : " + target.name);


            RemoveArrow();
        }
    }
    
    public void RemoveArrow()
    {
        ProjectileManager.Instance.arrowCount--;

        ProjectileManager.Instance.arrowList.Remove(this);
    }
}
