using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

	MenuFlow menuFlow;
	public void Initialize(MenuFlow _menuFlow)
	{
		menuFlow = _menuFlow;
	}

	public void PlayTheGame() {
		Debug.Log("play the Game");
		menuFlow.PlayButton();
	}

	public void Options() {

	}

	public void ExitGame() {
		menuFlow.ExitButton();
	}
}
