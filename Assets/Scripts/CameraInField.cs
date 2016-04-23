using UnityEngine;
using System.Collections;

public class CameraInField : MonoBehaviour {
	public GameObject target;
	public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
		Vector3 tar = target.transform.position;
		this.transform.position = tar + offset;
	
	}
}
