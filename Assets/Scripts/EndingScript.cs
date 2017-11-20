using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour {
	public Text endText;
	public TextAsset EndDialogue;
	public string[] textLines;
	int currentLine;

	public Animator sakiFace;
	public GameObject saki;
	// Use this for initialization
	void Start () {
		if (EndDialogue != null) {
			textLines = (EndDialogue.text.Split ('\n'));
		}
		sakiFace = saki.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		endText.text = textLines [currentLine];
		if (Input.GetKeyDown (KeyCode.Space)) {
			currentLine += 1;
		}

		if (comboReader.statChecker <= -8) {
			//F RANK
			currentLine = 38;
		}
		if (comboReader.statChecker > -8 && comboReader.statChecker <= 8) {
			//D RANK
			currentLine = 31;
		}
		if (comboReader.statChecker > 8 && comboReader.statChecker <= 24) {
			//C RANK
			currentLine = 24;
		}
		if (comboReader.statChecker > 24 && comboReader.statChecker <= 40) {
			//B RANK
			currentLine = 16;
		}
		if (comboReader.statChecker > 40 && comboReader.statChecker <= 56) {
			//A RANK
			currentLine = 9;
		}
		if (comboReader.statChecker > 56 && comboReader.statChecker <= 72) {
			//S RANK
			currentLine = 2;
		}

		if (currentLine == 2 || currentLine == 3) {
			//sakiFace.Play(blush)
		}
		if (currentLine == 4) {
			//sakiFace.Play(heart)
		}
	}
}
