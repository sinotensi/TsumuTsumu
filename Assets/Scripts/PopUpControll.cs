using UnityEngine;
using uGUI;
using System.Collections;

public class PopUpControll : MonoBehaviour {
	private bool aniFlag = false;
	private uTweenScale ts = new uTweenScale();
	private uTweenAlpha ta = new uTweenAlpha();

	private Vector3 newFrom = new Vector3();
	private Vector3 newTo = new Vector3();
	private float newDuration = 0.1f;

	public Vector3 originalFrom = new Vector3( 0, 0, 0 );
	public Vector3 originalTo = new Vector3( 1.05f, 1.05f, 1.05f );

	// Use this for initialization
	void Start () {
		Initialize();
	}

	/// <summary>
	/// Initialize all data.
	/// </summary>
	void Initialize () {
		ts = this.GetComponent<uTweenScale>();
		ta = this.GetComponent<uTweenAlpha>();
		
		ts.from = originalFrom;
		ts.to = originalTo;
		
		newFrom = ts.to;
		newTo = new Vector3( 1, 1, 1 );
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
			ts.from = newTo;
			ts.to = originalTo;
			ta.from = 1;
			ta.to = 0;
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

	/// <summary>
	/// Popup close animation.
	/// </summary>
	public void CloseAnimation () {
		newFrom = ts.to;
		newTo = originalFrom;
		newDuration = 0.5f;
		aniFlag = !aniFlag;
		ts.Play();
		ta.Play();
	}
}
