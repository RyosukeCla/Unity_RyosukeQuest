using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultManager : MonoBehaviour {
	private WholeGameManager wgm;
	public Text stext;
	public Text text;
	// Use this for initialization
	void Start () {
		wgm = GameObject.Find ("GameManager").GetComponent<WholeGameManager>();
		for (int i = 1; i < 4; i++) {
			for (int j = 0; j < 9; j++) {
				int ra = (int)Random.Range(0,6);
				wgm.PlusStatus (wgm.StatusName(ra), i, 1);
			}
		}
		wgm.limit = 10;
		wgm.statusNum = 0;
		UpdateStatusText ();
		KosinText ();

	}

	public void UpdateStatusText () {
		stext.text = wgm.ForResult ();
	}

	public void ChangeStatus(int num) {
		wgm.FirstCharacterCreate (num);
	}
	public void ChangeStatusNum (int value) {
		wgm.ChangeStatusNum (value);
	}

	public void Continue() {
		if (wgm.isPositive () && wgm.limit == 0) {
			Application.LoadLevelAsync("Field");
		}
	}

	public void KosinText() {
		text.text = wgm.StatusName (wgm.statusNum);
	}
}
