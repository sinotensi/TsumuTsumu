using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GachaView : MonoBehaviour {
	private Dictionary<int, Action> GachaAction = new Dictionary<int, Action>();

	public static bool GaCha = false;
	public Animator Gun;
	public Animator shootMan;
	public Animator Move;
	public Animator Anser;
	public Animator Mark;
	public ParticleSystem Explode;
	public GameObject Menu;
	public GameObject touchMsg;

	public int stap;
	public int gachaSelect;
	private CameraControll sceneCamera;

	// Use this for initialization
	void Start () {
		Initialize();
	}

	void Initialize () {
		GaCha = false;
		sceneCamera = GameObject.Find( "AnserLight" ).GetComponentInChildren<CameraControll>();
		sceneCamera.Initialize();
		GachaAction.Add( 1, NormalGacha );
		GachaAction.Add( 2, SuperGacha );
		touchMsg.SetActive( false );
		Explode.Stop();
	}

	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown( KeyCode.F1 ) )
		{
			GaCha = true;
			Gun.SetBool( "Play", true );
			shootMan.SetBool( "Play", true );
			StartCoroutine( stopAnimation() );
			StartCoroutine( NormalWaitAnser() );
		}

		if( Input.GetKeyDown( KeyCode.F2 ) )
		{
			GaCha = true;
			Gun.SetBool( "Play", true );
			shootMan.SetBool( "Play", true );
			StartCoroutine( stopAnimation() );
			StartCoroutine( SuperWaitAnser() );
		}

		if( Input.GetKeyDown( KeyCode.F3 ) )
		{

		}

		if( Input.anyKeyDown )
		{
			touchMsg.SetActive( false );
			GachaActionSet();
		}
	}

	public void SetNormalGacha () {
		gachaSelect = 1;
		Menu.SetActive( false );
		touchMsg.SetActive( true );
	}

	public void SetSuperGacha () {
		gachaSelect = 2;
		Menu.SetActive( false );
		touchMsg.SetActive( true );
	}

	public void GachaActionSet () {
		if( GachaAction.ContainsKey( gachaSelect ) )
		{
			GachaAction[gachaSelect]();
		}
	}

	public void NormalGacha () {
		GaCha = true;
		Gun.SetBool( "Play", true );
		shootMan.SetBool( "Play", true );
		StartCoroutine( stopAnimation() );
		StartCoroutine( NormalWaitAnser() );
	}
	
	public void SuperGacha () {
		GaCha = true;
		Gun.SetBool( "Play", true );
		shootMan.SetBool( "Play", true );
		StartCoroutine( stopAnimation() );
		StartCoroutine( SuperWaitAnser() );
	}
	
	public void AnimationCheck ( int rare ) {
		if( rare >= 2 )
		{
			Mark.SetBool( "Play", true );
		}
	}

	IEnumerator stopAnimation () {
		yield return new WaitForSeconds( 1 );

		Gun.SetBool( "Play", false );
		shootMan.SetBool( "Play", false );
	}

	IEnumerable ShootBomb () {
		yield return new WaitForSeconds( 0.1f );

		Explode.Play();
	}

	IEnumerator NormalWaitAnser () {
		yield return new WaitForSeconds( 5 );

		Gun.SetInteger( "Stap", 1 );
		shootMan.SetInteger( "Stap", 1 );
		Move.SetInteger( "Stap", 1 );
		StartCoroutine( FadeInOut.FadeOut() );
		int rare = GachaFormula.NormalFormaule();
		AnimationCheck( rare );
		yield return new WaitForSeconds( 0.85f );
		Explode.Play();
		Anser.SetInteger( "RareLv", rare );
	}

	IEnumerator SuperWaitAnser () {
		yield return new WaitForSeconds( 5 );
		
		Gun.SetInteger( "Stap", 1 );
		shootMan.SetInteger( "Stap", 1 );
		Move.SetInteger( "Stap", 1 );
		StartCoroutine( FadeInOut.FadeOut() );
		int rare = GachaFormula.SuperFormaule();
		AnimationCheck( rare );
		yield return new WaitForSeconds( 0.85f );
		Explode.Play();
		Anser.SetInteger( "RareLv", rare );
	}
}
