using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BG_Panel : MonoBehaviour {
	public Image BG1;
	public Image BG2;

	private List<Sprite> bgList = new List<Sprite>();

	// Use this for initialization
	void Start () {
		foreach( Sprite sp in Resources.LoadAll<Sprite>( "BackGround" ) )
		{
			bgList.Add( sp );
		}

		int bgId = RandomBG();
		BG1.sprite = bgList[bgId];
		BG2.sprite = bgList[bgId];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int RandomBG () {
		return Random.Range( 0, bgList.Count );
	}
}
