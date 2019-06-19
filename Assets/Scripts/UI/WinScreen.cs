using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
	//WinFlow winFlow;
	UIManager uiManager;


	public void Initialize(UIManager _uiManager)
	{
		//string s = Time.time.ToString("00:00")
		uiManager = _uiManager;
	}

	public void PlayAgain() {
		Debug.Log("Play again was called");
		UIManager.Instance.TryAgainButton();
	}



}
