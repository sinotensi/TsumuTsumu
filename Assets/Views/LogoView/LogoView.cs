using UnityEngine;
using uGUI;
using System.Collections;

public class LogoView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( LogoAnimation.End )
		{
			Debug.Log( "Next scene!" );
			SceneController.NextScene( "LoginView" );
		}
	}
}
