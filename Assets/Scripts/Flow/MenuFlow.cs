using UnityEngine;
using UnityEngine.UI;

public class MenuFlow : Flow
{
    Canvas menuCanvas;
    Button playButton, optionsButton, exitButton;
    MainEntry mainEntry;

    public override void Initialize()
    {
        mainEntry = GameObject.FindObjectOfType<MainEntry>();
        InputManager.Instance.Initialize();
        initialized = true;
    }

    public override void Update(float dt)
    {
        InputManager.Instance.UpdateManager();

        if (InputManager.Instance.inputPressed.jumpPressed)
        {
            PlayButton();
        }

        Debug.Log("MENUFLOW");
    }

    public override void FixedUpdate(float dt)
    {
        InputManager.Instance.FixedUpdateManager();
    }

    public override void EndFlow()
    {
        InputManager.Instance.StopManager();
    }

    void PlayButton()
    {
        Debug.Log("PLAY");
        mainEntry.GoToNextFlow(CurrentState.Menu);//Go to next Flow and the scene that is attatched to it.
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
