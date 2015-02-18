using UnityEngine;
using System.Collections;

public class LoginView : MonoBehaviour {
	public GameObject loading;

	// Use this for initialization
	void Start () {
		loading.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () {
		if( ClickCheck() )
		{
			ConnectLoading ();
		}
	}

	bool ClickCheck () {
		bool flag = false;
		if(Input.anyKeyDown || Input.touchCount > 0)
		{
			flag = true;
		}

		return flag;
	}

	void ConnectLoading () {
		loading.SetActive( true );
	}
}
