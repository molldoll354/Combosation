using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanzaOne : MonoBehaviour {
	
	bool PickedRight;
	bool PickedWrong1;
	bool PickedWrong2;
	string FirstStanza = "Shall I compare thee to a summer’s day?\nThou art more lovely and more temperate.  \nRough winds do shake the darling buds of May,";
	string LastLine1 = "And summer’s lease hath all too short a date.";
	string LastLine2= "And summer's fleece hath all too short a cape.";
	string LastLine3= "And I forgot a jacket mate.";
	public float TimeToSwitch;

	// Use this for initialization
	void Start () {
		
		PickedRight = false;
		PickedWrong1 = false;
		PickedWrong2 = false;
		//TimeToSwitch = 50;
		ReadPoetry.activeString = FirstStanza;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("" + TimeToSwitch);
		if(Input.GetButton("Submit")){
			//ReadPoetry.activeString = FirstStanza;
		}

	

		if (COMBOLIST.RomanceCombo1.Check ()) {
			PickedRight = true;
			Debug.Log ("Hit");
		}
		if (COMBOLIST.SincereCombo1.Check ()) {
			PickedWrong1 = true;
		}
		if (COMBOLIST.JokingCombo1.Check ()) {
			PickedWrong2 = true;
		}

		if (PickedRight == true) {
			Debug.Log ("YOU PICKED THE RIGHT!!");
			TimeToSwitch--;
			ReadCorrect.triggered = true;
			ReadCorrect.correctString = LastLine1;

			// Debug.Log ("" + PickedRight);

		}

		if (PickedWrong1 == true) {
			TimeToSwitch--;
			ReadCorrect.correctString = LastLine2;
		}
		if(PickedWrong2==true){
			TimeToSwitch--;
			ReadCorrect.correctString=LastLine3;
		}
			if (TimeToSwitch == 0) {
				StanzaManager.Stanza2Active = true;
			}
		}
	}

