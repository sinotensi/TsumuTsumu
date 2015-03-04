using UnityEngine;
using System.Collections;

public class LoginView : MonoBehaviour {
	public GameObject loadingObj;

	// Use this for initialization
	void Start () {
		Initialize();
	}

	/// <summary>
	/// Initialize all data.
	/// </summary>
	void Initialize () {
		loadingObj.SetActive( false );
	}

	// Update is called once per frame
	void Update () {
		if( ClickCheck() )
		{
			GoToLoginScene();
		}
	}

	/// <summary>
	/// Check Click state.
	/// </summary>
	/// <returns><c>true</c>, if was clicked, <c>false</c> otherwise.</returns>
	bool ClickCheck () {
		if( Input.anyKeyDown || Input.touchCount > 0 )
		{
			return true;
		}

		return false;
	}

	/// <summary>
	/// Gos to login scene.
	/// </summary>
	void GoToLoginScene () {
		loadingObj.SetActive( true );
		Loading._state = Loading.State.Login;
	}
}
