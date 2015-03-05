using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class NewUserView : MonoBehaviour {
	public static GameObject Mask;
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
		Mask = GameObject.Find( "Mask" );
		nameInput = GameObject.Find( "NameInput" );
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
			Loading._state = Loading.State.MyPageView;
			SceneController.NextScene( "LoadingView" );
		}
		else
		{
			Mask.SetActive( false );
			nameInput.SetActive( true );
		}
	}
}
