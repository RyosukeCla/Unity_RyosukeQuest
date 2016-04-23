using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusUpdate : MonoBehaviour {
	private Text text;
	private GameObject GameManager;
	private WholeGameManager wgm;
	public int num;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		GameManager = GameObject.Find ("GameManager");
		wgm = GameManager.GetComponent<WholeGameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = wgm.BattleStatus (num);
	}
}
