using UnityEngine;
using uGUI;
using System.Collections;

public class FadeInOut : MonoBehaviour {
	public static uTweenAlpha ta;

	// Use this for initialization
	void Start () {
		ta = GetComponent<uTweenAlpha>();
		ta.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static IEnumerator FadeOut () {
		yield return new WaitForSeconds( 1.5f );
		ta.from = 0;
		ta.to = 1;
		ta.Play();
	}

	public void NextScene () {
		Loading._state = Loading.State.GetPetView;
		SceneController.NextScene( "LoadingView" );
	}
}
