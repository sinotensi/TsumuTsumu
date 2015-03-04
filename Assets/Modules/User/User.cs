using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class User : MonoBehaviour {
	public static string 		uUID;
	public static string 		uName;
	public static int 	 		uSta;
	public static int			uLv;
	public static int	 		uNowExp;
	public static int	 		uNextExp;
	public static int	 		uMoney;
	public static string 		uLoginTime;
	public static string		uActiveParty;

	/// <summary>
	/// Instance the user data.
	/// </summary>
	/// <param name="data">User data.</param>
	public static void Instance ( Dictionary<string, object> data ) {
		DataUpdate( data );
	}

	/// <summary>
	/// User datas update.
	/// </summary>
	/// <param name="data">New User data.</param>
	public static void DataUpdate ( Dictionary<string, object> data ) {
		uUID = (string)data["UID"];
		uName = (string)data["Name"];
		uSta = (int)data["Sta"];
		uLv = (int)data["Lv"];
		uNowExp = (int)data["ExpNow"];
		uNextExp = (int)data["ExpNext"];
		uMoney = (int)data["Gold"];
		uLoginTime = (string)data["LoginTime"];
		uActiveParty = (string)data["party1"];
	}

	/// <summary>
	/// Create UID number.
	/// </summary>
	/// <returns>The user interface.</returns>
	public static string CreateUID () {
		int value = Random.Range( 0, 10000 );
		return string.Format( "{0:0000}", value );
	}
}
