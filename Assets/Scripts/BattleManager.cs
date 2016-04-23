using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleManager : MonoBehaviour {
	private WholeGameManager wgm;
	public Scrollbar sb;
	public float activeTime;
	public Text targetText;
	private int targetNum;
	public Text pl, mi, en1, en2;
	public GameObject gpl, gmi, gen1, gen2;
	private int playerHP, playerMP, mikataHP, mikataMP;
	private int[] enemHP = new int[2];
	private int[] enemMP = new int[2];
	private float[] activateBar = new float[3];
	public float mikataAc, enem1Ac, enem2Ac;
	public Text log;
	public ParticleSystem pa;

	// Use this for initialization
	void Start () {
		wgm = GameObject.Find ("GameManager").GetComponent<WholeGameManager>();
		SetupState ();
		targetNum = 0;
		UpdateText ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
		CanAttack ();
		ActiveTurn ();
		Adjustment ();
		UpdateOtherCharacter ();
		UpdateText ();
	}

	void UpdateOtherCharacter() {
		UpdateActivateBar ();
		CanAttackOthers ();
	}
	void UpdateActivateBar() {
		for (int i = 0; i < 3; i++) {
			activateBar [i] += Time.deltaTime;
		}
	}
	void CanAttackOthers() {
		// mikata no syori
		float rand = Random.Range (0.0f,1.0f);
		if (activateBar [0] > mikataAc && mikataHP > 0) {
			if (rand < 0.25f) {
				enemHP[0] -= AttakPoint (wgm.GetStatus("AT", 1), wgm.GetStatus("DF", 2));
				log.text = wgm.GetName(1) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("AT", 1), wgm.GetStatus("DF", 2))+"no-damege";
			} else if (rand < 0.5f) {
				enemHP[1] -= AttakPoint (wgm.GetStatus("AT", 1), wgm.GetStatus("DF", 3));
				log.text = wgm.GetName(1) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("AT", 1), wgm.GetStatus("DF", 3))+"no-damege";
			} else if (rand < 0.75f) {
				if (mikataMP > 0) {
					mikataMP--;
					enemHP[0] -= AttakPoint (wgm.GetStatus("MA", 1), wgm.GetStatus("SP", 2));
					log.text = wgm.GetName(1) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("MA", 1), wgm.GetStatus("SP", 2))+"no-damege";
				}
			} else {
				if (mikataMP > 0) {
					mikataMP--;
					enemHP[1] -= AttakPoint (wgm.GetStatus("MA", 1), wgm.GetStatus("SP", 3));
					log.text = wgm.GetName(1) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("MA", 1), wgm.GetStatus("SP", 3))+"no-damege";
				}
			}
			activateBar [0] = 0.0f;
		}
		// enem1 no syori
		if (activateBar [1] > enem1Ac && enemHP[0] > 0) {
			if (rand < 0.25f) {
				playerHP -= AttakPoint (wgm.GetStatus("AT", 2), wgm.GetStatus("DF", 0));
				log.text = wgm.GetName(2) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("AT", 2), wgm.GetStatus("DF", 0))+"no-damege";
			} else if (rand < 0.5f) {
				if (mikataHP > 0) {
					mikataHP -= AttakPoint (wgm.GetStatus("AT", 2), wgm.GetStatus("DF", 1));
					log.text = wgm.GetName(2) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("AT", 2), wgm.GetStatus("DF", 1))+"no-damege";
				}
			} else if (rand < 0.75f) {
				if (enemMP[0] > 0) {
					enemMP[0]--;
					playerHP -= AttakPoint (wgm.GetStatus("MA", 2), wgm.GetStatus("SP", 0));
					log.text = wgm.GetName(2) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("MA", 1), wgm.GetStatus("SP", 0))+"no-damege";
				}
			} else {
				if (mikataMP > 0) {
					if (enemMP[0] > 0) {
						enemMP[0]--;
						mikataHP -= AttakPoint (wgm.GetStatus("MA", 2), wgm.GetStatus("SP", 1));
						log.text = wgm.GetName(2) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("MA", 1), wgm.GetStatus("SP", 1))+"no-damege";
					}
				}
			}
			activateBar[1] = 0.0f;
		}
		// enem2 no syori
		if (activateBar [2] > enem2Ac && enemHP[1] > 0) {
			if (rand < 0.25f) {
				playerHP -= AttakPoint (wgm.GetStatus("AT", 3), wgm.GetStatus("DF", 0));
				log.text = wgm.GetName(2) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("AT", 3), wgm.GetStatus("DF", 0))+"no-damege";
			} else if (rand < 0.5f) {
				if (mikataHP > 0) {
					mikataHP -= AttakPoint (wgm.GetStatus("AT", 3), wgm.GetStatus("DF", 1));
					log.text = wgm.GetName(2) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("AT", 3), wgm.GetStatus("DF", 1))+"no-damege";
				}
			} else if (rand < 0.75f) {
				if (enemMP[1] > 0) {
					enemMP[1]--;
					playerHP -= AttakPoint (wgm.GetStatus("MA", 3), wgm.GetStatus("SP", 0));
					log.text = wgm.GetName(2) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("MA", 3), wgm.GetStatus("SP", 0))+"no-damege";
				}
			} else {
				if (mikataHP > 0) {
					if (enemMP[1] > 0) {
						enemMP[1]--;
						mikataHP -= AttakPoint (wgm.GetStatus("MA", 3), wgm.GetStatus("SP", 1));
						log.text = wgm.GetName(2) + "-no-kogeki-"+AttakPoint (wgm.GetStatus("MA", 3), wgm.GetStatus("SP", 1))+"no-damege";
					}
				}
			}
			activateBar[2] = 0.0f;
		}
	}

	void SetupState() {
		for (int i = 0; i < 3; i++) {
			activateBar[0] = 0.0f;
		}
		playerHP = wgm.GetStatus ("HP", 0);
		playerMP = wgm.GetStatus ("MP", 0);
		mikataHP = wgm.GetStatus ("HP", 1);
		mikataMP = wgm.GetStatus ("MP", 1);
		enemHP[0] = wgm.GetStatus ("HP", 2);
		enemMP[0] = wgm.GetStatus ("MP", 2);
		enemHP[1] = wgm.GetStatus ("HP", 3);
		enemMP[1] = wgm.GetStatus ("MP", 3);
	}

	void Adjustment() {
		int jud = 0;
		if (playerHP <= 0) {
			Application.LoadLevel("End");
		}
		if (mikataHP <= 0) {
			gmi.SetActive(false);
		}
		if (enemHP [0] <= 0) {
			gen1.SetActive(false);
			jud++;
		}
		if (enemHP [1] <= 0) {
			gen2.SetActive(false);
			jud++;
		}
		if (jud >= 2) {
			Application.LoadLevelAsync("Result");
		}
	}

	public void UpdateText() {
		pl.text = BattleStatus (0);
		mi.text = BattleStatus (1);
		en1.text = BattleStatus (2);
		en2.text = BattleStatus (3);
	}

	string BattleStatus (int num) {
		string str = "";
		str += wgm.GetName (num) +  "\n";
		if (num == 0) {
			str += "HP: " + playerHP + "\n";
			str += "MP: " + playerMP;
		} else if (num == 1) {
			str += "HP: " + mikataHP + "\n";
			str += "MP: " + mikataMP;
		} else if (num == 2) {
			str += "HP: " + enemHP[0] + "\n";
			str += "MP: " + enemMP[0];
		} else if (num == 3) {
			str += "HP: " + enemHP[1] + "\n";
			str += "MP: " + enemMP[1];
		}
		return str;
	}

	void ActiveTurn() {
		sb.value += activeTime * Time.deltaTime;
	}

	public void Attack() {
		if (sb.value == 1.0f) {
			enemHP[targetNum] -= AttakPoint (wgm.GetStatus("AT", 0), wgm.GetStatus("DF", targetNum+2));
			sb.value = 0.0f;
		}
	}

	public void Magic() {
		if (sb.value == 1.0f && playerMP > 0) {
			playerMP--;
			enemHP[targetNum] -= AttakPoint (wgm.GetStatus("MA",0), wgm.GetStatus("SP", targetNum+2));
			sb.value = 0.0f;
			pa.Play ();
		}
	}

	int AttakPoint(int at, int df) {
		int temp = at - df;
		if (temp < 1)
			temp = 1;
		return temp;
	}

	void CanAttack() {
		targetText.text = wgm.GetName (targetNum + 2);
	}

	// value 0 or 1
	public void ChangeTarget() {
		if (targetNum == 0)
			targetNum = 1;
		else
			targetNum = 0;
	}

}
