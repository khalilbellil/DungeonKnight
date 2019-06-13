using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public LayerMask mask;
    public Vector2 grid;
    public float nodeRadius;
    public float distance;

    bool[,] gridColiders;
    Vector2[,] realGrid;
    Node[,] gridN;
    public List<Node> FinalPath;
    
    int gridSizeX, gridSizeY;

    public Grid()
    {
        for (int i = 0; i < 44; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                realGrid[i, j] = new Vector2((float)(i - 21.5), (float)(j - 11.5));
            }
        }

        for (int i = 0; i < 44; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                gridColiders[i, j] = Physics2D.OverlapPoint(realGrid[i, j], LayerMask.GetMask("Objects", "Walls", "RoomSet"), -Mathf.Infinity, +Mathf.Infinity);
            }
        }
    }

    public int SearchInList(List<Node> l, Node n)
    {
        for (int i = 0; i < l.Count;i++)
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
        list.Remove(list[minIndex]);

        return result;
    }

    public List<Node> SearchNeighboorNodes(Node n, Transform goal)
    {
        List<Node> result = new List<Node>();

        int[,] v = new  int[,]{ {0,1}, {1,0}, {0,-1}, {-1,0}, {1,1}, {-1,1}, {-1,-1}, {1,-1} };

        for (int i = 0; i < 8; i++)
        {
            Vector2 tempv2 = n.position;
            tempv2.x += v[i, 0];
            tempv2.y += v[0, i];

            if (gridColiders[(int)tempv2.x,(int)tempv2.y] == false)
            {
                double d = Mathf.Sqrt(tempv2.x * tempv2.x + tempv2.y * tempv2.y);
                result.Add(new Node(tempv2,n.gCost + (int)d, Hcost(tempv2, goal), n));
            }
            
        }

        return result;

    }

    public bool Astar(Transform position, Transform goal)
    {
        List<Node> openList = new List<Node>();
        List<Node> closeList = new List<Node>();
        
        bool PathFound = false;

        openList.Add(new Node(new Vector2(Mathf.Round(position.position.x), Mathf.Round(position.position.y)), 0, Hcost(position.position,goal), null));

        while (openList != null)
        {
            Node n = SearchNode(openList);
            List<Node> path = new List<Node>();

            if (n.position.Equals(goal.position))
            {

                while (n.parent != null)
                {
                    path.Add(n);
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

}
