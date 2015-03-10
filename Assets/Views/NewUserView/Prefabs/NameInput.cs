using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class NameInput : MonoBehaviour {
	Dictionary<string, object> user = new Dictionary<string, object>();
	Dictionary<string, object> lv = new Dictionary<string, object>();

	public Button ok_Button;
	public Text inputText;
	public Text btnText;

	private string text = "";
	private bool inputFlag = false;

	private Color lockColor = new Color( 0.5f, 0.5f, 0.5f, 1 );
	private Color openColor = new Color( 1, 1, 1, 1 );

	// Use this for initialization
	void Start () {
		Initialize();
	}

	/// <summary>
	/// Initialize all data.
	/// </summary>
	void Initialize () {
		user = Json.Deserialize ( JSON_Manager.jsonUser ) as Dictionary<string, object>;
		lv = Json.Deserialize ( JSON_Manager.jsonLv ) as Dictionary<string, object>;
	}

	// Update is called once per frame
	void Update () {
		inputFlag = InputFlag_Check();
		ok_Button.image.color = ( inputFlag ) ? openColor : lockColor;
		btnText.color = ok_Button.image.color;
	}

	/// <summary>
	/// Check the name is correct.
	/// </summary>
	/// <returns><c>true</c>, if name is ok, <c>false</c> otherwise.</returns>
	public bool InputFlag_Check () {
		text = inputText.text;
		if( inputText.text != "" && text.IndexOf( " " ) == -1 && text.IndexOf( "　" ) == -1 )
		{
			return true;
		}

		return false;
	}

	/// <summary>
	/// the button event.
	/// </summary>
	public void OnOK () {
		if( inputFlag )
		{
			Name_Check();
		}
	}

	/// <summary>
	/// Check user name.
	/// </summary>
	public void Name_Check () {
		//Can check input name.

		InstanceUser();
		PlayerPrefs.SetString( "UserId", (string)user["UID"] );

		string savedata = Json.Serialize( user );
		JSON_Manager.JsonFile_SaveByPrefs( JSON_Manager.savePath[0], savedata );

		Loading._state = Loading.State.MyPageView;
		SceneController.NextScene( "LoadingView" );
	}

	/// <summary>
	/// Instances the user data.
	/// </summary>
	public void InstanceUser () {
		Debug.Log( user );
		string lvKey = ((long)user["Lv"]).ToString();
		List<object> data = (List<object>)(lv[lvKey]);

		user["UID"] = User.CreateUID() + "-" + User.CreateUID() + "-" + User.CreateUID();
		user["Name"] = inputText.text;
		user["StaNow"] = (long)data[1];
		user["StaMax"] = (long)data[1];
		user["Cost"] = (long)data[0];
		user["LoginTime"] = TimeManager.GetNowTime();
	}
}
