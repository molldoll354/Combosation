using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SakiAnswer3{
	public List<string> options;
}

public class comboReader3 : MonoBehaviour {

	private static comboReader3 _instance;

	public static comboReader3 Instance { get { return _instance; } }

	enum buttonType{W = 0, A = 1, S = 2, D = 3, Tie = 4};

	public string Source;
	public string[,] preREsponses;
	public List<string> preMadeCombos; //first is for the input command, the second is for the response
	List <int> buttonCount;

	public List<string> questions;
	public List<SakiAnswer> responses;
	public int questionIndex =0;
	public int finalAnswer =0;
	//public bool canPlayerSpeak = true;
	// Use this for initialization

	public enum ResponseOps3{
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
		preREsponses = new string[3,2] { 
			{"ASA","fake news"},
			{"WWSS", "news that aint true"},
			{"DSSWD", "true news"}};
//		preREsponses[0,0] = new string[,] {"ASA","fake news"};
//		preREsponses [1,0] = new string[,]{"WWSS", "news that aint true"};
//		preREsponses [2,0] = new string[,]{"DSSWD", "true news"};
		preMadeCombos = GetComponent<newInput1> ().preMadeCombos;
		Debug.Log (questions [questionIndex]);
		GetComponent<newInput> ().canPlayerSpeak = true;
		//		buttonType mostPressedButton = CheckButtonCounts (Source);
		//responses [questionIndex].options [(int)mostPressedButton];
		//buttonType mostPressedButton = CheckButtonCounts (Source);
	}

	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.P)) {
//			gameObject.SetActive(false);
//		}
//		Debug.Log ("noPress");
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			Debug.Log (responses [questionIndex].options [(int)CheckButtonCounts(Source)]);//pull the button type into responseops
//			questionIndex++;
//			Debug.Log (questions [questionIndex]);
//		}


	}

	public void readCombo(string Source){
		print (Source);
			//print ("in b4 Source=Getblabblab");
			//Source = GetComponent<newInput> ().inputCombo;
			//print ("" + questionIndex+" vs "+responses.Count);
			
		if(Source.Equals("ASA")){
			print ("ASA waS USED" );
		}else if (Source.Equals("WWSS")){
			print ("WWSS was used");
		}else if(Source.Equals("DSSWD")){
			print ("DSSWD was used");
		}
		else{
			Debug.Log (responses [questionIndex].options [(int)CheckButtonCounts(Source)]);//pull the button type into responseops
		}//print("b4 questionIndex++");
			questionIndex++;
			if(questionIndex < questions.Count){
				
				Debug.Log (questions [questionIndex]);
			} else {
				print("convo ended");
			}
			//print("b4 getcomponnent<>.playercanspeak=true");
			GetComponent<newInput> ().inputCombo = "";
			GetComponent<newInput> ().canPlayerSpeak = true;




	}
	public void readCombo(tempCombo combo){
		if(combo.comboName!= "random"){
			print (responses [questionIndex].options [combo.comboType]); 
		}
		else{
			print (combo.comboResponse);
		}
		questionIndex++;
		if(questionIndex < questions.Count){

			Debug.Log (questions [questionIndex]);
		} else {
			print("convo ended");
		}
		//print("b4 getcomponnent<>.playercanspeak=true");
		//GetComponent<newInput> ().inputCombo = "";
		//GetComponent<newInput> ().canPlayerSpeak = true;

	}

	public bool contains(string combo, List<string> totalCombos){
		bool onList = false;
		foreach (string wombo in totalCombos){
			int i = 0;
			if(totalCombos[i].Equals(combo)){onList = true; break;}
			i++;
		}
		return onList;
	}
	public int findIndex(string combo, string[,] totalCombos){
		int index = -1;
		foreach (string wombo in totalCombos){
			int i = 0;
			if(totalCombos[i,0].Equals(combo)){
				index = i; 
				print ("index has changed");
				break;

			}
			i++;
		}
		return index;
	}


	public ResponseOps3 CheckButtonCounts(string combo) {
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

		return (ResponseOps3)largestButtonType;
	}

}
