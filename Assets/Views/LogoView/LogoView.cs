using UnityEngine;
using uGUI;
using System.Collections;

public class LogoView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
		if( LogoAnimation.End )
		{
			SceneController.NextScene( "LoginView" );
		}
	}
}
