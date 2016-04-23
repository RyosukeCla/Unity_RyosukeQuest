using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WholeGameManager : MonoBehaviour {
	private static List<string> NAME = new List<string> ();
	private static List<int> HP = new List<int> ();
	private static List<int> MP = new List<int> ();
	private static List<int> AT = new List<int> ();
	private static List<int> DF = new List<int> ();
	private static List<int> MA = new List<int> ();
	private static List<int> SP = new List<int> ();

	public Vector3 playerPosition = new Vector3(0,1.5f,0);

	public InputField inputText;
	public Text text;
	public Text stext;
	public int limit;
	public int statusNum;

	void Awake() {
		DontDestroyOnLoad (this);
		SetCharacter ("Ryosuke", 1, 1, 1, 1, 1, 1);
		SetCharacter ("Bongo", 11, 1, 4, 3, 1, 1);
		SetCharacter ("Youtube", 13, 1, 4, 2, 1, 1);
		SetCharacter ("NicoNico", 6, 6, 1, 2, 5, 3);
	}

	// Use this for initialization
	void Start () {
		UpdateStatusTextFirst ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ExitCreateScene (string name) {
		if (isPositive() && limit == 0) {
			JumpTo (name);
		}
		else {
			stext.text = "Status has to be positive \n USE Point";
		}
	}

	public void UpdateStatusTextFirst () {
		string stat = "";
		stat += "Name : " + NAME [0] + "\n";
		stat += "HP : " + HP [0] + "\n";
		stat += "MP : " + MP [0] + "\n";
		stat += "AT : " + AT [0] + "\n";
		stat += "DF : " + DF [0] + "\n";
		stat += "MA : " + MA [0] + "\n";
		stat += "SP : " + SP [0] + "\n";
		stat += "Point : " + limit;
		text.text = stat;
		stext.text = StatusName (statusNum);
	}

	public string ForResult() {
		string stat = "";
		stat += "Name : " + NAME [0] + "\n";
		stat += "HP : " + HP [0] + "\n";
		stat += "MP : " + MP [0] + "\n";
		stat += "AT : " + AT [0] + "\n";
		stat += "DF : " + DF [0] + "\n";
		stat += "MA : " + MA [0] + "\n";
		stat += "SP : " + SP [0] + "\n";
		stat += "Point : " + limit;
		return stat;
	}

	public void FirstCharacterCreate(int value) {
		limit -= value;
		if (limit < 0) {
			limit = 0;
			return;
		}
		PlusStatus (StatusName(statusNum), 0, value);
	}

	public void FirstCharacterName() {
		NAME [0] = inputText.text;
	}
	
	public void ChangeStatusNum(int value) {
		statusNum += value;
		if (statusNum < 0)
			statusNum = 0;
		else if (statusNum > 5)
			statusNum = 5;
	}

	public string StatusName (int num) {
		if (num == 0) return "HP";
		else if (num == 1) return "MP";
		else if (num == 2) return "AT";
		else if (num == 3) return "DF";
		else if (num == 4) return "MA";
		else if (num == 5) return "SP";

		return "";
	}

	public string BattleStatus (int num) {
		string str = "";
		str += NAME [num] + "\n";
		str += "HP : " + HP [num] + "\n";
		str += "MP : " + MP [num];
		return str;
	}

	public void SetCharacter(string name, int hp, int mp, int at, int df, int ma, int sp) {
		NAME.Add (name);
		HP.Add (hp);
		MP.Add (mp);
		AT.Add (at);
		DF.Add (df);
		MA.Add (ma);
		SP.Add (sp);
	}

	public void PlusStatus (string st, int index, int value) {
		if (st == "HP") HP [index] += value;
		else if (st == "MP") MP [index] += value;
		else if (st == "AT") AT [index] += value;
		else if (st == "DF") DF [index] += value;
		else if (st == "MA") MA [index] += value;
		else if (st == "SP") SP [index] += value;
	}

	public void ChangeStatus (string st, int index, int value) {
		if (st == "HP") HP [index] = value;
		else if (st == "MP") MP [index] = value;
		else if (st == "AT") AT [index] = value;
		else if (st == "DF") DF [index] = value;
		else if (st == "MA") MA [index] = value;
		else if (st == "SP") SP [index] = value;
	}

	public void ChangeName (int index, string name) {
		NAME [index] = name;
	}

	public int GetStatus (string st, int index) {
		if (st == "HP")
			return HP [index];
		else if (st == "MP")
			return MP [index];
		else if (st == "AT")
			return AT [index];
		else if (st == "DF")
			return DF [index];
		else if (st == "MA")
			return MA [index];
		else if (st == "SP")
			return SP [index];

		return 0;
	}

	public bool isPositive() {
		if (HP [0] <= 0)
			return false;
		if (MP [0] <= 0)
			return false;
		if (AT [0] <= 0)
			return false;
		if (DF [0] <= 0)
			return false;
		if (MA [0] <= 0)
			return false;
		if (SP [0] <= 0)
			return false;
		return true;
	}

	public string GetName (int index) {
		return NAME[index];
	}

	public void JumpTo (string name) {
		Application.LoadLevel (name);
	}
}


