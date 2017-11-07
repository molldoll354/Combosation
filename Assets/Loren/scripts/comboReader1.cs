using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SakiAnswerTemp{
	public List<string> options;
}

public class comboReader1 : MonoBehaviour {

	private static comboReader1 _instance;

	public static comboReader1 Instance { get { return _instance; } }

	enum buttonType{W = 0, A = 1, S = 2, D = 3, Tie = 4};

	public string inputCombo;
	public Combo currentCombo;
	public bool canPlayerSpeak;

	List <int> buttonCount;

	public List<string> questions;
	public List<SakiAnswerTemp> responses;
	public int questionIndex =0;
	public int finalAnswer =0;
	//public bool canPlayerSpeak = true;
	// Use this for initialization

	public enum ResponseOpsTemp{
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
		GetComponent<newInput> ().canPlayerSpeak = true;
		//		buttonType mostPressedButton = CheckButtonCounts (Source);
		//responses [questionIndex].options [(int)mostPressedButton];
		//buttonType mostPressedButton = CheckButtonCounts (Source);
	}

	// Update is called once per frame
	void Update () {

		if (canPlayerSpeak == true) {
			if (inputCombo.Length < 5) {
				if (Input.GetKeyDown (KeyCode.A)) {
					inputCombo += "A";
				} else if (Input.GetKeyDown (KeyCode.W)) {
					inputCombo += "W";
				} else if (Input.GetKeyDown (KeyCode.S)) {
					inputCombo += "S";
				} else if (Input.GetKeyDown (KeyCode.D)) {
					inputCombo += "D";
				}
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				/*
				 *take string, return combo
				 *check if this combo exists
				 *yes: increment usage,
				 *no: add it to list<combo>
				 *
				 *take combo, reutn null
				 *
				 *take combo, return int
				 *
				 *
				 *convert combo into int to corralated with a response
				 *	check type
				 *		int = type
				 *
				 *	checks if premade,
				 *		yes: says new line instead.
				 *		no:  nothing
				 *	check length
				 *   >Length: set int to 5?
				 *   <Lenght: nothing
				 * 
				 *   check usage
				 * 		>Usage: set int to 6?
				 * 		<Usage: nothing
				 * 
				 * 
				 */
			

				canPlayerSpeak = false;
				print ("pressed space >>" + inputCombo);

			}

		}
		else if(Input.GetKeyDown(KeyCode.R)){
			canPlayerSpeak = true;
			inputCombo = "";
		}
	}

//		if (Input.GetKeyDown (KeyCode.P)) {
//			gameObject.SetActive(false);
//		}
//		Debug.Log ("noPress");
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			Debug.Log (responses [questionIndex].options [(int)CheckButtonCounts(Source)]);//pull the button type into responseops
//			questionIndex++;
//			Debug.Log (questions [questionIndex]);
//		}
//		if(GetComponent<newInput>().canPlayerSpeak == false){
//			//print ("in b4 Source=Getblabblab");
//			Source = GetComponent<newInput> ().inputCombo;
//			//print ("" + questionIndex+" vs "+responses.Count);
//			Debug.Log (responses [questionIndex].options [(int)CheckButtonCounts(Source)]);//pull the button type into responseops
//			//print("b4 questionIndex++");
//			if(questionIndex < questions.Count){
//				questionIndex++;
//				Debug.Log (questions [questionIndex]);
//			} else {
//				print("convo ended");
//			}
//			//print("b4 getcomponnent<>.playercanspeak=true");
//			GetComponent<newInput> ().inputCombo = "";
//			GetComponent<newInput> ().canPlayerSpeak = true;

		


	public ResponseOpsTemp CheckButtonCounts(string combo) {
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

//		what does this do y'all?
		// if (largestButtonType == buttonType.W) {
//			finalAnswer=(int)ResponseOpsTemp.chat;
//		} else if (largestButtonType == buttonType.A) {
//			finalAnswer=(int)ResponseOpsTemp.flatter;
//		} else if (largestButtonType == buttonType.S) {
//			finalAnswer=(int)ResponseOpsTemp.joke;
//		} else if (largestButtonType == buttonType.D) {
//			finalAnswer=(int)ResponseOpsTemp.flirt;
//		} else {
//			finalAnswer = (int)ResponseOpsTemp.other;
//		} 

		return (ResponseOpsTemp)largestButtonType;
	}

	public void compareCombo(string playerInput){


	}


	public bool tooLong(int preferedLength, string combo){
		bool tooLong = false;
		if(preferedLength<combo.Length){
			tooLong = true;
		}
		return tooLong;
	}

	public bool premade(string combo, List<Combo> comboPreList){
		bool preMade = false;
		foreach (Combo combos in comboPreList ){
			int i = 0;
			if(comboPreList[i].comboName != "random"){
				preMade = true;
				break;
			}
			i++;
		}
		return preMade;
	}

	public	bool tooUsed(tempCombo combo, List<Combo> totalComboList, int prefUsage){
		bool usedMuch = false;
		int i = 0;
		foreach (Combo comBo in totalComboList){
			if(totalComboList[i].comboInput.Equals(combo) 
				&& totalComboList[i].usage>prefUsage){
				usedMuch = true;
				break;
			}

		}  

		return usedMuch;
	}
	public bool contains(string combo, List<Combo> totalCombos){
		bool onList = false;
		foreach (Combo wombo in totalCombos){
			int i = 0;
			if(totalCombos[i].comboInput.Equals(combo)){onList = true; break;}
			i++;
		}
		return onList;
	}
}
