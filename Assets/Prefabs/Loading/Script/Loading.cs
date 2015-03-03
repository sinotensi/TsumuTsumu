using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Loading : MonoBehaviour {
	private Dictionary<State, Action> loadAction = new Dictionary<State, Action>();

	public enum State
	{
		Title,
		Login,
		CreateUser,
		LoadData,
		InTutorial,
		InGame,
		Party
	}

	public static State _state = State.Title;

	// Use this for initialization
	void Start () {
		loadAction.Add( State.Login, Login );
		loadAction.Add( State.CreateUser, CreateUser );
		loadAction.Add( State.LoadData, LoadData );
		loadAction.Add( State.InTutorial, Tutorial );
		loadAction.Add( State.InGame, GamePlay );
		loadAction.Add( State.Party, Party );
	}
	
	// Update is called once per frame
	void Update () {
		Action_Check();
	}

	/// <summary>
	/// Check Loading Action.
	/// </summary>
	void Action_Check () {
		if( loadAction.ContainsKey( _state ) )
		{
			loadAction[_state]();
		}
	}

	void Login () {
		SceneController.NextScene( "NewUserView" );
	}

	void CreateUser () {

	}

	void LoadData () {

	}

	void Tutorial () {

	}

	void GamePlay () {

	}

	void Party () {

	}


}
