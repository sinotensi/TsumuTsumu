using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JSON_Manager : MonoBehaviour {
	public static string[] loadPath = new string[]{ "User" };
	public static string[] savePath = new string[]{ "UserData.json" };

	/// <summary>
	/// Load json file from local DB.
	/// </summary>
	/// <returns>The file_ load.</returns>
	/// <param name="_path">File name.</param>
	public static Dictionary<string, object> JsonFile_Load ( string _path ) {
		Dictionary<string, object> json = new Dictionary<string, object>();

		TextAsset textAsset = Resources.Load( "DataBase/" + _path ) as TextAsset;
		string jsonData = textAsset.text;

		json = Json.Deserialize ( jsonData ) as Dictionary<string, object>;

		return json;
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
		writer.Close();
	}
}
