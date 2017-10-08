using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class openingDialogue : MonoBehaviour {
	public GameObject textBox;
	public Text theText;



	public TextAsset textFile;
	public string[] textLines;
	public int currentLine;
	public int lastLine;

	public GameObject button;
	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}
		button.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
			theText.text = textLines [currentLine];

		string s = textLines [currentLine];
		if (s.Contains ("Saki")) {//check if string contains a word*
			theText.color = Color.black;
		} else {
			theText.color = Color.white;
		}
		if (s.Contains ("INPUT COMBO")) {
			theText.text = "";
			button.SetActive(true);
		} else {
			button.SetActive(false);
		}

			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				currentLine += 1;
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				currentLine -= 1;
			}
		if(Input.GetKeyDown(KeyCode.RightArrow)&& currentLine==lastLine){	
			currentLine=0;
		}
		}
	}

