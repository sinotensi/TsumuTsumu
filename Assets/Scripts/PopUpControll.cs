using UnityEngine;
using uGUI;
using System.Collections;

public class PopUpControll : MonoBehaviour {
	private uTweenScale ts = new uTweenScale();

	private Vector3 newFrom = new Vector3();
	private Vector3 newTo = new Vector3();

	public Vector3 originalFrom = new Vector3( 0, 0, 0 );
	public Vector3 originalTo = new Vector3( 1.05f, 1.05f, 1.05f );

	private float newDuration = 0.1f;
	private bool aniFlag = false;
	public static bool End = false;

	// Use this for initialization
	void Start () {
		Initialize();
	}

	/// <summary>
	/// Initialize all data.
	/// </summary>
	void Initialize () {
		ts = this.GetComponent<uTweenScale>();
		
		ts.from = originalFrom;
		ts.to = originalTo;
		
		newFrom = ts.to;
		newTo = new Vector3( 1, 1, 1 );

		End = false;
	}

	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Set new Animation.
	/// </summary>
	public void NewAnimationSet () {
		if( !aniFlag )
		{
			ts.from = newFrom;
			ts.to = newTo;
			ts.duration = newDuration;
			ts.Play();
		}
		else
		{
			End = true;
		}
	}

	/// <summary>
	/// Popup open animation.
	/// </summary>
	public void OpenAnimation () {
		if( !aniFlag )
		{
			NewAnimationSet();
			aniFlag = !aniFlag;
		}
		else
		{
			NewAnimationSet();
		}
	}
}
