using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class newInput : MonoBehaviour {
	public string inputCombo;

	public GameObject happyFace, sadFace, loveFace;
	public GameObject flatter, joke, wink, chat, neutral;
	public Text meterText;
	public Text timeText;

	public bool comboOver;
	public bool StopButtons;
	public string[] combos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Get player input. 
		if (inputCombo.Length <= 5 && comboOver == false) {
			if (Input.GetKeyDown (KeyCode.A)) {
				inputCombo += "A";

			} else if (Input.GetKeyDown (KeyCode.W)) {
				Input += "W";
			} else if (Input.GetKeyDown (KeyCode.S)) {
				inputCombo += "A";

			} else if (Input.GetKeyDown (KeyCode.D)) {
				Input += "D";
			}
			else if(Input.GetKeyDown(KeyCode.Space)){
				comboOver = true;	
			}
		}
		else{ //COMPARE COMBOS




		}
	}
	bool CompareCombo(string playerCombo, string[] comboList){
		bool isIt = false;
		//if(comboList.GetHashCode (playerCombo))
		{
			isIt = true;
		}
		return isIt;
	}

}






