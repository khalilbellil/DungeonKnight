using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSCRIPT : MonoBehaviour
{
    //public delegate void MyDelegate();
    //public delegate int MyDelegate2(string b);
    //System.Action a1;


    // Start is called before the first frame update
    void Start()
    {
        /*
        MyDelegate d = Update;
        d = RoomManager.Instance.StopManager;
        d += Update;
        d.Invoke();
        d();

        MyDelegate2 d2 = funct;
        int i = d2.Invoke("shaaaaaamee");
        d = () => { Debug.Log("sdfs"); Debug.Log("sdfsdf"); } ;
        a1 =  () => Debug.Log("dsdd");

        d2 = (x) => { return x.Length };
        d2.Invoke("hey");*/

        Enemy e = new Enemy();
        List<Transition.MyDelegate> list = new List<Transition.MyDelegate>()
        {
            //(enemy) => { return e.GetRange() >= Vector2.Distance(PlayerManager.Instance.player.transform.position, e.transform.position); }
            (enemy) => { return e.GetRange() >= Vector2.Distance(new Vector2(1,1), new Vector2(9,9)); }

        };

        Transition t = new Transition(eUnitState.ATTACK, list, e);

        Debug.Log(t.Evluate());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int funct(string shamwow)
    {
        return 0;
    }
}
