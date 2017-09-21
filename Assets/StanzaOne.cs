using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanzaOne : MonoBehaviour {
	
	bool PickedRight;
	bool PickedWrong;
	string FirstStanza = "Shall I compare thee to a summer’s day?\nThou art more lovely and more temperate.  \nRough winds do shake the darling buds of May,";
	string LastLine1 = "And summer’s lease hath all too short a date.";
	public float TimeToSwitch;
	// Use this for initialization
	void Start () {
		PickedRight = false;
		PickedWrong = false;
		//TimeToSwitch = 50;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("" + TimeToSwitch);
		if(Input.GetButton("Submit")){
			ReadPoetry.activeString = FirstStanza;
		}
		if (COMBOLIST.RomanceCombo1.Check ()) {
			PickedRight = true;
			//Debug.Log ("Hit");
		}
		if (COMBOLIST.SincereCombo1.Check ()) {
			PickedWrong = true;
		}
		if (COMBOLIST.JokingCombo1.Check ()) {
			PickedWrong = true;
		}

		if (PickedRight == true) {
			TimeToSwitch--;
			ReadCorrect.correctString = LastLine1;
			// Debug.Log ("" + PickedRight);

		}
			if (TimeToSwitch == 0) {
				StanzaManager.Stanza2Active = true;
			}
		}
	}

