using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class GetPetView : MonoBehaviour {
	Dictionary<string, object> pet = new Dictionary<string, object>();
	Dictionary<string, object> petState = new Dictionary<string, object>();
	Dictionary<string, object> N_petExp = new Dictionary<string, object>();
	Dictionary<string, object> R_petExp = new Dictionary<string, object>();
	Dictionary<string, object> SR_petExp = new Dictionary<string, object>();
	Dictionary<string, object> petData = new Dictionary<string, object>();
	Dictionary<string, object> user = new Dictionary<string, object>();

	public Text petName;
	public Image petImage;
	public Text rareText;
	public Text lvText;
	public Text hpText;
	public Text atkText;
	public Text healText;
	public Text costText;
	public Slider expSlider;
	public Slider hpSlider;
	public Slider atkSlider;
	public Slider healSlider;

	public static string petUID = "";

	// Use this for initialization
	void Start () {
		Initialize();
	}

	void Initialize () {
		pet = Json.Deserialize ( JSON_Manager.jsonPet ) as Dictionary<string, object>;
		petState = Json.Deserialize ( JSON_Manager.jsonPetState ) as Dictionary<string, object>;
		N_petExp = Json.Deserialize ( JSON_Manager.jsonNPetExp ) as Dictionary<string, object>;
		R_petExp = Json.Deserialize ( JSON_Manager.jsonRPetExp ) as Dictionary<string, object>;
		SR_petExp = Json.Deserialize ( JSON_Manager.jsonSRPetExp ) as Dictionary<string, object>;

		user = JSON_Manager.JsonFile_LoadByPrefs( JSON_Manager.savePath[0] );

		List<object> state = (List<object>)(petState[petUID]);
		List<object> parmeta = new List<object>();
		switch( (string)pet["Rare"] )
		{
		case "N":
			parmeta = (List<object>)(N_petExp["1"]);
			break;
		case "R":
			parmeta = (List<object>)(R_petExp["1"]);
			break;
		case "SR":
			parmeta = (List<object>)(SR_petExp["1"]);
			break;
		}

		Debug.Log( parmeta.Count );

		pet["UID"] = petUID;
		pet["ID"] = (long)user["PetsLen"];
		pet["Name"] = (string)state[0];
		pet["Rare"] = (string)state[2];
		pet["Attribute"] = (string)state[3];
		pet["Cost"] = (long)state[1];

		//pet["InnateID"] = ;
		//pet["SkillID"] = ;
		pet["CharaPath"] = "Pet/Image/" + petUID;
		pet["IconPath"] = "Pet/Icon/" + petUID;

		petName.text = (string)state[0];
		petImage.sprite = Resources.Load<Sprite>( (string)pet["CharaPath"] );
		rareText.text = (string)state[2];
		lvText.text = ((long)pet["Lv"]).ToString();

		costText.text = "Cost : " + ((long)state[1]).ToString();

		expSlider.maxValue = (float)((long)parmeta[0]);
		expSlider.maxValue = (float)((long)parmeta[1]);
		expSlider.value = (float)((long)pet["Exp"]);

		switch( petUID )
		{
		case "u00001":
			petData = Json.Deserialize ( JSON_Manager.jsonPetData[0] ) as Dictionary<string, object>;
			break;
		case "u00002":
			petData = Json.Deserialize ( JSON_Manager.jsonPetData[1] ) as Dictionary<string, object>;
			break;
		case "u00003":
			petData = Json.Deserialize ( JSON_Manager.jsonPetData[2] ) as Dictionary<string, object>;
			break;
		case "u00004":
			petData = Json.Deserialize ( JSON_Manager.jsonPetData[3] ) as Dictionary<string, object>;
			break;
		case "u00005":
			petData = Json.Deserialize ( JSON_Manager.jsonPetData[4] ) as Dictionary<string, object>;
			break;
		}
		parmeta = (List<object>)(petData["1"]);
		hpText.text = ((long)parmeta[0]).ToString();
		atkText.text = ((long)parmeta[1]).ToString();
		healText.text = ((long)parmeta[2]).ToString();
		pet["Hp"] = (long)parmeta[0];
		pet["Atk"] = (long)parmeta[1];
		pet["Heal"] = (long)parmeta[2];

		parmeta = (List<object>)(petData["5"]);

		hpSlider.maxValue = (float)((long)parmeta[0]);
		hpSlider.value = (float)((long)pet["Hp"]);
		atkSlider.maxValue = (float)((long)parmeta[1]);
		atkSlider.value = (float)((long)pet["Atk"]);
		healSlider.maxValue = (float)((long)parmeta[2]);
		healSlider.value = (float)((long)pet["Heal"]);
		UserDataUpdate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UserDataUpdate () {
		long len = (long)user["PetsLen"];
		len++;
		user["PetsLen"] = len;
		string savedata = Json.Serialize( user );
		JSON_Manager.JsonFile_SaveByPrefs( JSON_Manager.savePath[0], savedata );
	}

	public void OnBack () {
		Loading._state = Loading.State.GachaView;
		SceneController.NextScene( "LoadingView" );
	}
}
