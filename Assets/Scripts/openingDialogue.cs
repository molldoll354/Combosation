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
	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}
	}
	// Update is called once per frame
	void Update () {
			theText.text = textLines [currentLine];

			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				currentLine += 1;
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				currentLine -= 1;
			}
				


		}
	}

