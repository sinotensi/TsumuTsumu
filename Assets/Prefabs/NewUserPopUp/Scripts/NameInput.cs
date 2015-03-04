using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class NameInput : MonoBehaviour {
	private PopUpControll popControll;
	Dictionary<string, object> json = new Dictionary<string, object>();

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
		popControll = this.GetComponent<PopUpControll>();
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
		PlayerPrefs.SetString( "UserId", (string)json["UID"] );
		JSON_Manager.JsonFile_Save( JSON_Manager.savePath[0], json );
		Loading._state = Loading.State.CreateUser;
		popControll.CloseAnimation();
		NewUserView.loadingObj.SetActive( true );
	}

	/// <summary>
	/// Instances the user data.
	/// </summary>
	public void InstanceUser () {
		json = JSON_Manager.JsonFile_Load( JSON_Manager.loadPath[0] );

		json["UID"] = User.CreateUID() + "-" + User.CreateUID() + "-" + User.CreateUID();
		json["Name"] = inputText.text;
		json["LoginTime"] = TimeManager.GetNowTime();
	}
}
