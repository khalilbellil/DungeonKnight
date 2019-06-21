using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
	//WinFlow winFlow;
	UIManager uiManager;
	UILinksWin uILinksWin;


	public void Initialize(UIManager _uiManager)
	{
		//string s = Time.time.ToString("00:00")
		uiManager = _uiManager;
	}

	public void PlayAgain() {
		Debug.Log("Play again was called");
		UIManager.Instance.TryAgainButton();
	}

	public void ReturnToMainMenu()
	{
		Debug.Log("Main menu was called");
		UIManager.Instance.BackToMainMenuButton();
	}

	public void GetTime() {
		//uILinksWin.timeDisplay.text = Timer.Instance.UpdateTimer();
		//uiLinks.timer.text = Timer.Instance.minutes + ":" + Timer.Instance.seconds;
	}

}
