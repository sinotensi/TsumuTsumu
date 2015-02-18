using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	public static void NextScene ( string sceneName ) {
		Application.LoadLevel( sceneName );
	}
}
