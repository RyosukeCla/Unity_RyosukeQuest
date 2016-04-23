using UnityEngine;
using System.Collections;

public class Encounter : MonoBehaviour {
	public float possibility;
	public float interval;

	// Use this for initialization
	void Start () {
		StartCoroutine (Encount());
	}

	IEnumerator Encount() {
		while (true) {
			yield return new WaitForSeconds (interval);
			if (Random.Range(0,1) < possibility) {
				Application.LoadLevelAsync ("Battle");
			}
		}
	}
}
