using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LaunchSlime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchSlime()
    {
        YeetSlime yS = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.slimeDir)).GetComponent<YeetSlime>();
        yS.transform.position = new Vector3(7,12,0);
        yS.Init();
        yS.Launched(new Vector2(0, 1));

    }
}
