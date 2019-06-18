using UnityEngine;
using UnityEngine.UI;

public class MenuFlow : Flow
{
    Canvas menuCanvas;
    Button playButton, optionsButton, exitButton;
    MainEntry mainEntry;
	MainMenu menu;

    public override void Initialize()
    {

		menu = GameObject.FindObjectOfType<MainMenu>();
		menu.Initialize(this);
		mainEntry = GameObject.FindObjectOfType<MainEntry>();
        InputManager.Instance.Initialize();
        initialized = true;
        Debug.Log("MenuFlow init");
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

    public void PlayButton()
    {
        Debug.Log("PLAY");
        mainEntry.GoToNextFlow(CurrentState.Menu);//Switch to Game Scene/Flow.
    }

    void OptionsButton()
    {
        Debug.Log("OPTIONS");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }

}
