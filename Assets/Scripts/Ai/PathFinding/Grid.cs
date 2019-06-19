using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public LayerMask mask;
    public Vector2 grid;
    public float nodeRadius;
    public float distance;

    static bool[,] gridColiders = new bool[45, 25];
    Node[,] gridN;
    public List<Node> FinalPath = new List<Node>();

    int gridSizeX, gridSizeY;

    public static void InitBoolGrid()
    {
        Vector2[,] realGrid = new Vector2[45, 25];
        for (int i = 0; i < 45; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                realGrid[i, j] = new Vector2((float)(i), (float)(j));
            }
        }

        for (int i = 0; i < 45; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                gridColiders[i, j] = Physics2D.OverlapPoint(realGrid[i, j] + new Vector2(.5f, .5f), LayerMask.GetMask("Objects", "Walls", "RoomSet", "Doors"), -Mathf.Infinity, +Mathf.Infinity);
            }
        }
    }

    public Grid()
    {

    }

    public int SearchInList(List<Node> l, Node n)
    {
        for (int i = 0; i < l.Count; i++)
        {
            if (l[i].position == n.position)
            {
                return i;
            }
        }
        return -1;
    }

    public Node SearchInList(HashSet<Node> l, Node n)
    {
        Node node = null;

        if (l.Contains(n))
        {
            node = n;
        }

        return node;
    }

    public int Hcost(Vector2 position, Transform goal)
    {
        int Row = (int)((goal.position.x) - (position.x));
        int Col = (int)((goal.position.y) - (position.y));

        return (int)(Row * Row + Col * Col);
    }

    public Node SearchNode(HashSet<Node> list)
    {
        Node result = new Node(new Vector2(0, 0), 10, 100000, null);
        foreach (Node n in list)
        {
            if (n.fCost < result.fCost)
            {
                result = n;
            }
        }

        list.Remove(result);

        return result;
    }

    public HashSet<Node> SearchNeighboorNodes(Node n, Transform goal)
    {
        HashSet<Node> result = new HashSet<Node>();

        int[,] v = new int[,] { { -1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 } };

        for (int i = 0; i < 8; i++)
        {
            Vector2Int gridLocToCheck = n.gridLoc;

            gridLocToCheck.x += v[i, 0];
            gridLocToCheck.y += v[i, 1];

            try
            {
                if (!IsWallAtLocation(gridLocToCheck))
                {
                    float d = Mathf.Sqrt((n.gridLoc.x - gridLocToCheck.x) * (n.gridLoc.x - gridLocToCheck.x) + (n.gridLoc.y - gridLocToCheck.y) * (n.gridLoc.y - gridLocToCheck.y));
                    result.Add(new Node(gridLocToCheck, n.gCost + (int)d, Hcost(gridLocToCheck, goal), n));
                }
            }
            catch
            {
                Debug.LogError("");
            }

        }

        return result;
    }

    private bool IsWallAtLocation(Vector2Int locToCheck)
    {
        if ((locToCheck.x < 0 || locToCheck.x > 43) || (locToCheck.y < 0 || locToCheck.y > 23))//y...
        {
            return true;
        }
        return gridColiders[(locToCheck.x), (locToCheck.y)];
    }

    private int CalcGCost(Vector2 goalPos, Vector2Int gridLoc) { return 0; }

    public bool Astar(Transform position, Transform goal)
    {
        FinalPath.Clear();
        HashSet<Node> openListH = new HashSet<Node>();
        HashSet<Node> closeListH = new HashSet<Node>();

        if (goal != null)
        {
            
            openListH.Add(new Node(new Vector2(position.position.x + 0.5f, position.position.y + 0.5f), 0, Hcost(position.position, goal), null));

            while (openListH.Count > 0)
            {
                Node n = SearchNode(openListH);
                if ((n.position.x >= (goal.position.x - 1) && n.position.y >= (goal.position.y - 1)) && (n.position.x <= (goal.position.x + 1) && n.position.y <= (goal.position.y + 1)))
                {
                    while (n.parent != null)
                    {
                        FinalPath.Add(n);
                        n = n.parent;
                    }

                    return true;
                }

                closeListH.Add(n);

                HashSet<Node> neighboors = SearchNeighboorNodes(n, goal);

                Node optimalNeighbor;
                int lowestCost = int.MaxValue;
                foreach (Node no in neighboors)
                {
                    /*if(!closeListH.Contains(no))
                    {
                        int currentCost = CalcGCost(goal.position, no.gridLoc);
                        if(currentCost < lowestCost)
                        {
                            optimalNeighbor = no;
                            lowestCost = currentCost;
                        }

                    }

                    if(openListH.Contains(no))
                    {

                        //
                    }*/
                    

                    Node node = SearchInList(openListH, no);
                    

                    if (SearchInList(closeListH, no) != null)
                    {

                    }
                    else if (node != null)
                    {
                        if (node.gCost > no.gCost)
                        {
                            node = no;
                        }
                    }
                    else
                    {
                        openListH.Add(no);
                    }
                }
            }
        }

        return false;
    }

    public List<Node> GetPath()
    {
        return FinalPath;
    }

}
