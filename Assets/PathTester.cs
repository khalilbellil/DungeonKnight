using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTester : MonoBehaviour
{
    bool initialize = false;
    Grid grid;
    public Transform goal;
    // Update is called once per frame
    void Update()
    {
        if(!initialize)
        {
            initialize = true;
            grid = new Grid();
        }
        else
        {
            grid.Astar(this.transform, goal);
            List<Node> finalPath = grid.GetPath();
            if (finalPath.Count > 0)
            {
                Vector2 dir = (finalPath[0].position - (Vector2)transform.position).normalized;
                //Debug.Log("Dir: " + dir);
            }
            else
            {
                //Debug.Log("Arrived at destination");
            }
        }
    }
}
