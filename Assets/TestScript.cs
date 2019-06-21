using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Item.LoadItem(Item.AllItems.potion, new Vector3(7, 12, 0));
        Item.LoadItem(Item.AllItems.passive, new Vector3(12, 12, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
