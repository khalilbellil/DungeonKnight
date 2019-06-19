using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrapTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check is player & etc
        transform.parent.GetComponent<BossRoom>().TrapTriggerEntered(collision.transform);

    }
}
