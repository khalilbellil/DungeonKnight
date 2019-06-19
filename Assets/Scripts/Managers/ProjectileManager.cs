using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager
{
    #region Singleton Pattern
    private static ProjectileManager instance = null;
    private ProjectileManager() { }
    public static ProjectileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ProjectileManager();
            }
            return instance;
        }
    }
    #endregion

    public List<Arrow> arrowList;
    public int arrowCount;

    public void Initialize()
    {
        arrowList = new List<Arrow>();
        arrowCount = 0;
    }

    public void UpdateManager(float dt)
    {
        foreach(Arrow a in arrowList)
        {
            a.UpdateArrow(dt);
        }
    }

    public void FixedUpdateManager(float dt)
    {
        
    }

    public void StopManager()
    {//Reset everything
        instance = null;
    }

    public void CreateArrow(Bow.BowPkg bowPkg)
    {
        arrowCount++;
        arrowList.Add(new Arrow());
        arrowList[arrowCount - 1].Init(bowPkg);
    }

}
