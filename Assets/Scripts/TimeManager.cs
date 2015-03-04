using UnityEngine;
using System;
using System.Collections;

public class TimeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Get system time.
	/// </summary>
	/// <returns>The now time.</returns>
	public static string GetNowTime () {
		string year = DateTime.Now.Year.ToString();
		string month = DateTime.Now.Month.ToString();
		string day = DateTime.Now.Day.ToString();
		string hour = DateTime.Now.Hour.ToString();
		string minute = DateTime.Now.Minute.ToString();
		string second = DateTime.Now.Second.ToString();

		string time = year + month + day + hour + minute + second;

		return time;
	}
}
