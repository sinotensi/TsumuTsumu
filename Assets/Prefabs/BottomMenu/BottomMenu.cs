using UnityEngine;
using uGUI;
using System.Collections;

public class BottomMenu : MonoBehaviour {
	public uTweenPosition tp;

	public bool animaFlag = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AnimationSet () {
		if( !animaFlag )
		{
			tp.from = tp.to;
			tp.to = new Vector3( 0.0f, -495f, 0.0f );
			tp.duration = 0.3f;
			tp.Play();
			animaFlag = true;
		}
	}
}
