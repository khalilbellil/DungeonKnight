using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlow : Flow
{
	WinScreen winScreen;
	MainEntry mainEntry;


	public override void Initialize()
	{
		winScreen = GameObject.FindObjectOfType<WinScreen>();
		winScreen.Initialize(this);
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
			TryAgainButton();
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

	public void TryAgainButton()
	{
		Debug.Log("PLAY");
		mainEntry.GoToNextFlow(CurrentState.Menu);//Switch to Game Scene/Flow.
	}
}
