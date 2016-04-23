using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {
	public void Exit() {
		Debug.Log ("QUit");
		Application.Quit ();
	}
}
