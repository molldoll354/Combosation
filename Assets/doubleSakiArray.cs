using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
//public class SakiAnswer{
//	public List<string> options;
//}

public class doubleSakiArray : MonoBehaviour {
	public List<string> questions;
	public List<SakiAnswer> responses;
	int questionIndex;
	public Text theText;
	// Use this for initialization

	enum ResponseOps{
		joke=0,
		chat=1,
		flirt=2,
		flatter=3,
		other = 4,

	}
	void Start () {
		Debug.Log (questions [questionIndex]);
//		buttonType mostPressedButton = CheckButtonCounts (Source);
//		responses [questionIndex].options [(int)mostPressedButton];
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {
			gameObject.SetActive(false);
		}
		Debug.Log ("noPress");
		if (Input.GetKeyDown (KeyCode.W)) {
			Debug.Log ("howdy!");
			Debug.Log (responses [questionIndex].options [(int)ResponseOps.joke]);//pull the button type into responseops
						questionIndex++;
						Debug.Log (questions [questionIndex]);
		}

	}
}
