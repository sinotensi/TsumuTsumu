using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JSON_Manager : MonoBehaviour {
	public static string[] loadDBPath = new string[]{ "User", "UserLv" };
	public static string[] loadPath = new string[]{ "UserData" };
	public static string[] savePath = new string[]{ "UserData.json" };

	public static string jsonUser = "";
	public static string jsonLv = "";
	/// <summary>
	/// Initialize all data.
	/// </summary>
	public static void Initialize () {
		jsonUser = JsonDBFile_Load( loadDBPath[0] );
		jsonLv = JsonDBFile_Load( loadDBPath[1] );
	}

	/// <summary>
	/// Load json file from local DB.
	/// </summary>
	/// <returns>The file_ load.</returns>
	/// <param name="_path">File name.</param>
	public static string JsonDBFile_Load ( string _path ) {
		TextAsset textAsset = Resources.Load( "DataBase/" + _path ) as TextAsset;
		
		string jsonData = textAsset.text;

		return jsonData;
	}

	/// <summary>
	/// Load json file from local DB.
	/// </summary>
	/// <returns>The file_ load.</returns>
	/// <param name="_path">File name.</param>
//	public static Dictionary<string, object> JsonFile_Load ( string _path ) {
//		Dictionary<string, object> json = new Dictionary<string, object>();
//
//		TextAsset textAsset = Resources.Load( "SaveData/" + _path ) as TextAsset;
//		string jsonData = textAsset.text;
//		
//		json = Json.Deserialize ( jsonData ) as Dictionary<string, object>;
//		
//		return json;
//	}

	public static Dictionary<string, object> JsonFile_LoadByPrefs ( string _path ) {
		Dictionary<string, object> json = new Dictionary<string, object>();

		if( PlayerPrefs.HasKey( _path ) )
		{
			string jsonData = PlayerPrefs.GetString( _path );
			
			json = Json.Deserialize ( jsonData ) as Dictionary<string, object>;
			
			return json;
		}

		return null;
	}

	/// <summary>
	/// Save json file to local.
	/// </summary>
	/// <param name="_path">File name.</param>
	/// <param name="data">Data.</param>
	public static void JsonFile_Save ( string _path, Dictionary<string, object> data ) {
		StreamWriter writer = null;

		string path = @Application.dataPath + "/Resources/SaveData/" + _path;

		// false：Duplicate、true：Add
		writer = new StreamWriter( path, false, System.Text.Encoding.Default );
		
		writer.Write( Json.Serialize( data ) );
		writer.Flush();
		writer.Close();
	}

	public static void JsonFile_SaveByPrefs ( string _path, string data ) {
		PlayerPrefs.SetString( _path, data );
	}
}
