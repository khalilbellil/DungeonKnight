using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	//WinFlow winFlow;
	UIManager uiManager;


	public void Initialize(UIManager _uiManager)
	{
		//string s = Time.time.ToString("00:00")
		uiManager = _uiManager;
	}

	public void PlayAgain()
	{
		Debug.Log("Play again was called");
		UIManager.Instance.TryAgainButton();
	}

	public void ReturnToMainMenu()
	{
		Debug.Log("Main menu was called");
		UIManager.Instance.BackToMainMenuButton();
	}

}
