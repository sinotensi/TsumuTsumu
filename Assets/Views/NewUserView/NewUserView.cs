using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class NewUserView : MonoBehaviour {
	public static GameObject loadingObj;
	public static GameObject nameInput;

	// Use this for initialization
	void Start () {
		Initialize();
		UserDataCheck();
	}

	/// <summary>
	/// Initialize all data.
	/// </summary>
	void Initialize () {
		loadingObj = GameObject.Find( "Loading" );
		nameInput = GameObject.Find( "NameInput" );
		loadingObj.SetActive( false );
		nameInput.SetActive( false );
	}

	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Check have save data.
	/// </summary>
	void UserDataCheck () {
		if( PlayerPrefs.HasKey( "UserId" ) )
		{
			Loading._state = Loading.State.CreateUser;
			loadingObj.SetActive( true );
		}
		else
		{
			nameInput.SetActive( true );
		}
	}
}
