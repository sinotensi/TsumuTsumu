using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class MyPageView : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnQuest () {
	
	}

	public void OnPets () {
		Loading._state = Loading.State.PetsView;
		SceneController.NextScene( "LoadingView" );
	}

	public void OnGacya () {

	}

	public void OnOption () {

	}
}
