using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    //public bool isBlocked;
    public Vector2 position;
    public Vector2Int gridLoc;

    public Node parent;

    public int gCost;
    public int hCost;

    public int fCost;

    public Node(/*bool isBlocked,*/ Vector2 position, int gCost, int hCost, Node parent)
    {
        //this.isBlocked = isBlocked;

        this.position = position;
        this.gridLoc = new Vector2Int((int)position.x, (int)position.y);
        this.gCost = gCost;
        this.hCost = hCost;
        this.fCost = gCost + hCost;
        this.parent = parent;
    }

    public override int GetHashCode()
    {
        return gridLoc.GetHashCode() ;
    }

    public override bool Equals(object obj)
    {
        if (typeof(Node) == obj.GetType())
            return gridLoc == ((Node)obj).gridLoc;
        return false;
    }
}
