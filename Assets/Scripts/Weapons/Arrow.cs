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

    public void Init(Bow.BowPkg bowPkg)
    {

        arrowStats = bowPkg;
        isTravelling = true;
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = arrowStats.dir * arrowStats.arrowSpeed * arrowStats.speedModifier;

        transform.position = arrowStats.owner.transform.position;
        transform.eulerAngles = new Vector3(0, 0, arrowStats.dir.ToAngle());
        //Debug.Log("Ang: " + arrowStats.dir.ToAngle());
    }

    public void UpdateArrow(float dt)
    {
        if (isTravelling)
        {
            distanceToCheck = arrowStats.arrowSpeed * arrowStats.dir.magnitude * dt;
            Attack();
        }
    }

    public void Attack()
    {

        target = Physics2D.Raycast(transform.position, arrowStats.dir, distanceToCheck, arrowStats.layerToHit).collider;       //returns the collider of the RayCastHit2D from the layer given

        if (target != null)
        {
    //need to change so it is not only enemy that can hit (testing purposes)
                target.GetComponent<BaseUnit>().TakeDamage(arrowStats.dammage);
                Debug.Log("Target hp : " + target.GetComponent<BaseUnit>().health);

            isTravelling = false;


            Debug.Log("Hit a target ! : " + target.name);


            RemoveArrow();
        }
    }
    
    public void RemoveArrow()
    {
        ProjectileManager.Instance.RemoveProjectile(this);
    }
}
