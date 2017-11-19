using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour {
	public Text endText;
	public TextAsset EndDialogue;
	public string[] textLines;
	int currentLine;
	// Use this for initialization
	void Start () {
		if (EndDialogue != null) {
			textLines = (EndDialogue.text.Split ('\n'));
		}
	}
	
	// Update is called once per frame
	void Update () {
		endText.text = textLines [currentLine];
		if (Input.GetKeyDown (KeyCode.Space)) {
			currentLine += 1;
		}
			

	}
}
