using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanzaTwo : MonoBehaviour {

	bool PickedRight;
	bool PickedWrong;
	string SecondStanza = "Sometime too hot the eye of heaven shines,\nAnd often is his gold complexion dimmed;\nAnd every fair from fair sometime declines,";
	string LastLine2 = "By chance, or nature’s changing course, untrimmed;";
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
			ReadPoetry.activeString = SecondStanza;
		}
		if (COMBOLIST.RomanceCombo2.Check ()) {
			PickedRight = true;
			//Debug.Log ("Hit");
		}
		if (COMBOLIST.SincereCombo2.Check ()) {
			PickedWrong = true;
		}
		if (COMBOLIST.JokingCombo2.Check ()) {
			PickedWrong = true;
		}

		if (PickedRight == true) {
			TimeToSwitch--;
			ReadCorrect.correctString = LastLine2;
			// Debug.Log ("" + PickedRight);

		}
		if (TimeToSwitch == 0) {
			StanzaManager.Stanza3Active = true;
		}
	}
}

