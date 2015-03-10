using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class Exp : MonoBehaviour {
	Dictionary<string, object> PetExpStart = new Dictionary<string, object>();
	// Use this for initialization
	void Start () {
		for( float i = 1; i < 200; ++i )
		{
			///EXP
			//float exp = 156 * ( Mathf.Pow( ((i - 1)/98), 25.0f/10.0f ) );
			///HP
			//float hp = 1085 * ( Mathf.Pow( ((i - 1)/98), 1.75f/10.0f ) );
			///ATK
			//float atk = 644 * ( Mathf.Pow( ((i - 1)/98), 25.0f/10.0f ) );
			///REHP
			float heal = 159 * ( Mathf.Pow( ((i - 1)/98), 25.0f/10.0f ) );
			PetExpStart.Add( i.ToString(), Mathf.Ceil( heal ) );
		}

		Debug.Log( Json.Serialize( PetExpStart ) );
	}
	
	// Update is called once per frame
	void Update () {

	}
}
