using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private CharacterController cc;
	public float speed;
	private WholeGameManager wgm;
	// Use this for initialization
	void Start () {
		wgm = GameObject.Find ("GameManager").GetComponent<WholeGameManager>();
		this.transform.position = wgm.playerPosition;
		cc = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
		cc.Move (speed * move);
		wgm.playerPosition = this.transform.position;
	}
}
