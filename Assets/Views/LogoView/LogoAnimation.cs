using UnityEngine;
using uGUI;
using System.Collections;

public class LogoAnimation : MonoBehaviour {
	private uTweenAlpha alphaTween;
	
	private int tweenCount = 0;
	private int maxTween = 0;
	private float coolTime = 1.5f;

	public static bool End = false;
	// Use this for initialization
	void Start () {
		Initialize();
	}

	/// <summary>
	/// Initialization all data.
	/// </summary>
	void Initialize () {
		alphaTween = this.GetComponent<uTweenAlpha>();
	}

	// Update is called once per frame
	void Update () {
		
	}
	

	
	/// <summary>
	/// Tweens the end action.
	/// </summary>
	public void TweenEndAction () {
		if( tweenCount <= maxTween )
		{
			StartCoroutine( LoopTween() );
			tweenCount++;
		}
		else
		{
			End = true;
		}
	}
	
	/// <summary>
	/// Loops the tween by tween count.
	/// </summary>
	/// <returns>Cool Time.</returns>
	IEnumerator LoopTween () {
		yield return new WaitForSeconds( coolTime );
		alphaTween.from = 1;
		alphaTween.to = 0;
		alphaTween.enabled = true;
		alphaTween.Play();
	}
}
