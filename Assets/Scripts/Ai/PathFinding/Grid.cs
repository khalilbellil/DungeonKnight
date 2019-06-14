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
                gridColiders[i, j] = Physics2D.OverlapPoint(realGrid[i, j] + new Vector2(.5f,.5f), LayerMask.GetMask("Objects", "Walls", "RoomSet", "Doors"), -Mathf.Infinity, +Mathf.Infinity);
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

    public int Hcost(Vector2 position, Transform goal)
    {
        int Row = (int)((goal.position.x) - (position.x));
        int Col = (int)((goal.position.y) - (position.y));

        return (int)(Mathf.Sqrt(Row * Row + Col * Col));
    }

    public Node SearchNode(List<Node> list)
    {
        Node result = list[0];
        int minIndex = 0;

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].fCost < result.fCost)
            {
                result = list[i];
                minIndex = i;
            }
        }

        list[minIndex] = list[list.Count - 1];
        list.Remove(list[list.Count - 1]);

        return result;
    }

    public List<Node> SearchNeighboorNodes(Node n, Transform goal)
    {
        List<Node> result = new List<Node>();

        int[,] v = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 }, { 1, 1 }, { -1, 1 }, { -1, -1 }, { 1, -1 } };

        for (int i = 0; i < 8; i++)
        {
            Vector2Int gridLocToCheck = n.gridLoc;

            gridLocToCheck.x += v[i, 0];
            gridLocToCheck.y += v[i, 1];

            //int a = (int)(tempv2.x);
            //int b = (int)(tempv2.y);
            try
            {
                bool addNode = !IsWallAtLocation(gridLocToCheck);
                if (!IsWallAtLocation(gridLocToCheck))
                {
                    double d = Mathf.Sqrt(gridLocToCheck.x * gridLocToCheck.x + gridLocToCheck.y * gridLocToCheck.y);
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
        return gridColiders[(int)(locToCheck.x), (int)(locToCheck.y)];
    }

    //private Vector2Int WorldPosToGridLoc(Vector2 v2)
    //{
    //    return 
    //}
    //
    //private Vector2 GridLocToWorld(Vector2Int v2)
    //{
    //
    //}

    public bool Astar(Transform position, Transform goal)
    {
        List<Node> openList = new List<Node>();
        List<Node> closeList = new List<Node>();
        
        bool PathFound = false;

        openList.Add(new Node(new Vector2(position.position.x, position.position.y), 0, Hcost(position.position,goal), null));

        while (openList.Count > 0)
        {
            Node n = SearchNode(openList);

            //Debug.Log("openList not empty");
            if (n.position == new Vector2(goal.position.x, goal.position.y))
            {
               // Debug.Log("Equals");
                while (n.parent != null)
                {
                    FinalPath.Add(n);
                    n = n.parent;
                }

                return true;
            }

            closeList.Add(n);

            List<Node> neighboors = SearchNeighboorNodes(n,goal);

            foreach (Node no in neighboors)
            {
                int indexOpen = SearchInList(openList, no);

                if (SearchInList(closeList, no) != -1)
                {

                }
                else if (indexOpen != -1)
                {
                    if (openList[indexOpen].gCost > no.gCost)
                    {
                        openList[indexOpen] = no;
                    }
                }
                else
                {
                    openList.Add(no);
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
