using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
	WinFlow winFlow;

	public void Initialize(WinFlow _winFlow)
	{
		//string s = Time.time.ToString("00:00")
		winFlow= _winFlow;
	}

	public void PlayAgain() {
		Debug.Log("Play again was called");
		UIManager.Instance.TryAgainButton();
	}



}
