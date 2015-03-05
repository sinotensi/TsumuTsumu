using UnityEngine;
using UnityEngine.UI;
using uGUI;
using System.Collections;

public class PetsView : MonoBehaviour {
	public uTweenPosition tp;
	public uTweenAlpha ta;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPartyEdit () {

	}

	public void OnUpGrade () {

	}

	public void OnEvolution () {

	}

	public void OnBook () {

	}

	public void OnSell () {

	}

	public void OnBack () {
		Loading._state = Loading.State.MyPageView;
		SceneController.NextScene( "LoadingView" );
	}

	public void OnOpen () {
		tp.from = new Vector3( -50, -50, 0 );
		tp.to = new Vector3( 0, -50, 0 );
		ta.from = 0;
		ta.to = 1;
		
		tp.Play();
		ta.Play();
	}

	public void OnClose () {
		tp.from = new Vector3( 0, -50, 0 );
		tp.to = new Vector3( -50, -50, 0 );
		ta.from = 1;
		ta.to = 0;

		tp.Play();
		ta.Play();
	}
}
