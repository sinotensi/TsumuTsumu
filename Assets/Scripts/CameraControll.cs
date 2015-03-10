using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {
	public float cameraSize;
	public float mSpeed;
	public float moveSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if( GachaView.GaCha )
		{
			AnimationSet();
		}
	}

	void AnimationSet () {
		if( Camera.main.orthographicSize - mSpeed > cameraSize )
		{
			Camera.main.orthographicSize = Camera.main.orthographicSize - mSpeed;
		}

		if( transform.localPosition.y - moveSpeed > 1.95f )
		{
			transform.localPosition = new Vector3( 0, transform.localPosition.y - moveSpeed, -10f );
		}
	}

	public void Initialize () {
		Camera.main.orthographicSize = 5.0f;
		transform.localPosition = new Vector3( 0, 3.4f, -10f );
	}
}
