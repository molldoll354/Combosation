﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SakiAnswer{
	public List<string> options;
}

public class comboReader : MonoBehaviour {

	private static comboReader _instance;

	public static comboReader Instance { get { return _instance; } }

	enum buttonType{W = 0, A = 1, S = 2, D = 3, Tie = 4};

	public string Source;

	List <int> buttonCount;

	public List<string> questions;
	public List<SakiAnswer> responses;
	int questionIndex;
	int finalAnswer;
	// Use this for initialization

	public enum ResponseOps{
		chat=0,
		flirt=1,
		joke=2,
		flatter=3,
		other = 4,

	}

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	void Start () {
		Debug.Log (questions [questionIndex]);
		//		buttonType mostPressedButton = CheckButtonCounts (Source);
		//		responses [questionIndex].options [(int)mostPressedButton];
		//buttonType mostPressedButton = CheckButtonCounts (Source);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {
			gameObject.SetActive(false);
		}
		Debug.Log ("noPress");
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log (responses [questionIndex].options [(int)CheckButtonCounts(Source)]);//pull the button type into responseops
			questionIndex++;
			Debug.Log (questions [questionIndex]);
		}

	}
	public ResponseOps CheckButtonCounts(string combo) {
		buttonCount = new List<int> ();
		buttonCount.Add (0);
		buttonCount.Add (0);
		buttonCount.Add (0);
		buttonCount.Add (0);
		buttonCount [(int)buttonType.W] = combo.Split ('W').Length - 1;
		buttonCount [(int)buttonType.A] = combo.Split ('A').Length - 1;
		buttonCount [(int)buttonType.S] = combo.Split ('S').Length - 1;
		buttonCount [(int)buttonType.D] = combo.Split ('D').Length - 1;
		buttonType largestButtonType = buttonType.W;
		int largestCount = buttonCount [(int)largestButtonType];

		for (int i = 1; i < 4; i++) {
			if (largestCount < buttonCount [i]) {
				largestCount = buttonCount [i];
				largestButtonType = (buttonType)i;
			} else if (largestCount == buttonCount [i]) {
				largestButtonType = buttonType.Tie;
				//break;
			}
		}

//		if (largestButtonType == buttonType.W) {
//			finalAnswer=(int)ResponseOps.chat;
//		} else if (largestButtonType == buttonType.A) {
//			finalAnswer=(int)ResponseOps.flatter;
//		} else if (largestButtonType == buttonType.S) {
//			finalAnswer=(int)ResponseOps.joke;
//		} else if (largestButtonType == buttonType.D) {
//			finalAnswer=(int)ResponseOps.flirt;
//		} else {
//			finalAnswer = (int)ResponseOps.other;
//		}

		return (ResponseOps)largestButtonType;
	}

}
