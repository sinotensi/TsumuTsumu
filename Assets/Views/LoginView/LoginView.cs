using UnityEngine;
using System.Collections;

public class LoginView : MonoBehaviour {
	public GameObject loadingObj;

	// Use this for initialization
	void Start () {
		loadingObj.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () {
		if( ClickCheck() )
		{
			ConnectLoading ();
		}
	}

	bool ClickCheck () {
		if( Input.anyKeyDown || Input.touchCount > 0 )
		{
			return true;
		}

		return false;
	}

	void ConnectLoading () {
		loadingObj.SetActive( true );
		Loading._state = Loading.State.Login;
	}
}
