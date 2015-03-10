using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class LoadingView : MonoBehaviour {
	public static string nextScene = "";
	public static Dictionary<string, object> user = new Dictionary<string, object>();
	public static bool End = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if( PopUpControll.End )
		{
			Load_Check();
		}
	}

	void Load_Check () {
		try
		{
			SaveDataCheck();

			End = true;
		}
		catch(Exception e)
		{
			Debug.Log( e.Message );
		}
	}

	/// <summary>
	/// Check save data.
	/// </summary>
	void SaveDataCheck () {
		user = JSON_Manager.JsonFile_LoadByPrefs( JSON_Manager.savePath[0] );
		
		if( user != null )
		{
			User.Instance( user );
		}
	}
}
