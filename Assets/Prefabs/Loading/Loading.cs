using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Loading : MonoBehaviour {
	public enum State
	{
		LogoView,
		LoginView,
		NewUserView,
		LoadingView,
		MyPageView,
		PetsView,
		GachaView,
		GetPetView
	}

	public static State _state = State.LogoView;
	public static string sceneName = "";

	// Use this for initialization
	void Start () {
		Initialize();
	}

	/// <summary>
	/// Initialize all data.
	/// </summary>
	void Initialize () {

	}

	// Update is called once per frame
	void Update () {
		if( LoadingView.End || PopUpControll.End )
		{
			LoadingView.End = false;
			PopUpControll.End = false;
			SceneLoad();
		}
	}

	/// <summary>
	/// Load next scene.
	/// </summary>
	public void SceneLoad () {
		SceneController.NextScene( _state.ToString() );
	}
}
