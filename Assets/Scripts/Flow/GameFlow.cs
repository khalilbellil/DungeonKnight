using UnityEngine;

public class GameFlow : Flow
{
    public override void Initialize()
    {


        initialized = true;
    }

    public override void Update(float dt)
    {

        Debug.Log("GAMEFLOW");
    }

    public override void FixedUpdate(float dt)
    {

    }

    public override void EndFlow()
    {

    }

}
