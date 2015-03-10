using UnityEngine;
using UnityEngine.UI;
using uGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class TopMenu : MonoBehaviour {
	public uTweenPosition tp;
	Dictionary<string, object> lv = new Dictionary<string, object>();

	public Text userName;
	public Text lvText;
	public Text staText;
	public Text coinText;
	public Slider lvSlider;
	public Slider staSlider;


	public bool animaFlag = false;

	// Use this for initialization
	void Start () {
		lv = Json.Deserialize ( JSON_Manager.jsonLv ) as Dictionary<string, object>;
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Initialize () {
		DataUpdate();
	}

	/// <summary>
	/// Set Menu Data.
	/// </summary>
	public void DataUpdate () {
		Debug.Log( "Updata user data!" );
		string lvKey = (User.uLv).ToString();
		List<object> data = (List<object>)(lv[lvKey]);
		
		long lvMinValue = (long)data[2];
		long lvNowValue = (long)User.uExp;
		long lvMaxValue = (long)data[3];
		userName.text = User.uName;
		lvText.text = "等級 : " + lvKey;
		staText.text = "體力 : " + User.uStaNow + "/" + User.uStaMax;
		coinText.text = Coin_Check ();
		lvSlider.minValue = (float)lvMinValue;
		lvSlider.maxValue = (float)lvMaxValue;
		lvSlider.value = (float)lvNowValue;

		staSlider.minValue = 0.0f;
		staSlider.maxValue = (float)User.uStaMax;
		staSlider.value = (float)User.uStaNow;
	}

	public string Coin_Check () {
		if( User.uCoin != 0 )
		{
			return string.Format( "{0:0,0}", User.uCoin );
		}

		return "0";
	}

	public void AnimationSet () {
		if( !animaFlag )
		{
			tp.from = tp.to;
			tp.to = new Vector3( 0.0f, 493f, 0.0f );
			tp.duration = 0.3f;
			tp.Play();
			animaFlag = true;
		}
	}
}
