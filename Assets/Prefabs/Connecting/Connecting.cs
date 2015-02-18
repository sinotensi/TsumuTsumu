using UnityEngine;
using System.Collections;

public class Connecting : MonoBehaviour {
	private float disTime = 0.0f;
	private float waitTime = 3.0f;
	private int reConnect = 0;
	private int maxReconnect = 4;

	// Use this for initialization
	void Start () {
		Initialization ();
		ConnectToServer ();
	}
	
	// Update is called once per frame
	void Update () {
		if( reConnect >= maxReconnect && !ConnectState() )
		{
			//Show error message.
			Debug.Log( "Show Connect error message." );
			Initialization ();
			this.gameObject.SetActive( false );
		}

		disTime = ( disTime < waitTime ) ? TimeCount() : ReConnect ();
	}

	void Initialization () {
		disTime = 0.0f;
		reConnect = 0;
	}

	float TimeCount ()
	{
		return disTime + Time.deltaTime;
	}

	/// <summary>
	/// try to Connect again.
	/// </summary>
	/// <returns>reset disTime.</returns>
	float ReConnect () {
		reConnect++;
		ConnectToServer();
		Debug.Log( "Connecting..." + reConnect );

		return 0.0f;
	}

	void ConnectToServer () {
		//Connect to server
	}

	/// <summary>
	/// Check connect state.
	/// </summary>
	/// <returns>
	/// <c>true</c>, if state was connected, 
	/// <c>false</c> otherwise.
	/// </returns>
	bool ConnectState () {
		bool state = false;

		//Check connect state.

		return state;
	}


}
