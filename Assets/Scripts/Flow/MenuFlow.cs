using UnityEngine;
using UnityEngine.UI;

public class MenuFlow : Flow
{
    Canvas menuCanvas;
    Button playButton, optionsButton, exitButton;

    public override void Initialize()
    {
        

        initialized = true;
    }

    public override void Update(float dt)
    {
        Debug.Log("MENUFLOW");
    }

    public override void FixedUpdate(float dt)
    {

    }

    public override void EndFlow()
    {

    }

    void PlayButton()
    {
        Debug.Log("PLAY");

        MainEntry.sceneNb = 2;//Switch to Game Scene
    }

    void OptionsButton()
    {
        Debug.Log("OPTIONS");

    }

    void ExitButton()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }

}
