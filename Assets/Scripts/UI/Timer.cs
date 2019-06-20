using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer
{
	#region Singleton Pattern
	private static Timer instance = null;
	private Timer() { }
	public static Timer Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Timer();
			}
			return instance;
		}
	}
	#endregion

	float startTime;
	public string minutes;
	public string seconds;


	// Start is called before the first frame update
	public void Initialize()
	{
		startTime = Time.time;
	}

	// Update is called once per frame
	public void UpdateTimer()
	{
		float t = Time.time - startTime;
		minutes = ((int)t / 60).ToString();
		seconds = (t % 60).ToString("00");	
	}
}
