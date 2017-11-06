using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newInput : MonoBehaviour {
	public string inputCombo="";

//	public GameObject happyFace, sadFace, loveFace;
//	public GameObject flatter, joke, wink, chat, neutral;
//	public Text meterText;
//	public Text timeText;

	public bool canPlayerSpeak;//controls when the player can input a combo
	public bool StopButtons;
	public int preferedLength;
	public int maxUsage;//max usage of a combo before "overused"
	public Combo[] premadeCombos;
	List<Combo> comboUsage = new List<Combo> ();

	//Dictionary<string, int> comboUsage;
	// Use this for initialization
	void Start () {
		premadeCombos = new Combo [3];
		premadeCombos [0] = new Combo ("ASA", "wholesome", 1, 2, 1, 0, 2, 2);
		premadeCombos [1] = new Combo ("WWSS","standup special", 4, 3, 0,0,1,2 );
		premadeCombos [2] = new Combo ("DSSWD", "smooth criminal", 4,4,4,4,0,2);
	}
	
	// Update is called once per frame
	void Update () {
		//Get player input. 
		if (canPlayerSpeak == true ) {
			if(inputCombo.Length < 5 )
			{
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

			if(Input.GetKeyDown(KeyCode.Space)){
				canPlayerSpeak = false;
				print ("pressed space >>"+inputCombo);
				//GetComponentInParent<comboReader> ().Source = inputCombo;
				//Debug.Log ("Press [R] to reset: Info>> " + compareCombo (preferedLength, inputCombo, premadeCombos));
				//print ("Press [R] to reset: Info>> " + compareCombo (preferedLength, inputCombo, premadeCombos, comboUsage));
			}

		}
		else { 
			if(Input.GetKeyDown(KeyCode.R)){ 
				canPlayerSpeak = true;
				inputCombo = "";

			}
		}
	}

	//<-------------------------------Functions----------------------->

	//compareCombo v2, now uses/needs a dictionary
	string compareCombo(int preferedComboLength, string playerCombo, Combo[] premadeComboList, List<Combo> usedCombos){
		string isIt = "";//the final string of info
		bool correctLength = false;
		bool premade = false;
		bool usedAlready = false;
		//testing length
		if(playerCombo.Length>preferedLength){ correctLength = true;}
		else{ isIt += "fit";}//langauge reflects length in attempts for improved readability

		//is this a premade combo
//		if(premadeComboList.Contains(playerCombo)==true){
//			isIt+=" premade";
//		} else { isIt+=" random";}
		foreach(Combo combo in premadeComboList){//checks if the combo is premade or not.
			int i =0;
			if (premadeComboList[i].comboInput.Equals(playerCombo)){
				premade = true;
				break;
			}
			i++;
		}
		foreach(Combo combo in usedCombos){//checks if  the  combo has been used before, and increments usage.
			int i = 0;
			if(usedCombos[i].comboInput.Equals(playerCombo)){
				usedAlready = true;
				usedCombos[i].usage+=1;
				break;
			}

			i++;
		}
		if(usedAlready==false){//adds the combo to the COmbo List, if necessary
			Combo newCombo = new Combo(playerCombo);
			usedCombos.Add(newCombo);
		}
//		if(usedCombos.Contains(playerCombo))
//		{ 
//			print ("used b4" + premadeComboList [playerCombo]);
//			usedCombos [playerCombo].usage += 1;
//			print ("used after " + premadeComboList [playerCombo]);
//			isIt += " used: " + usedCombos [playerCombo].usage;
//			print ("You've used this combo "+usedCombos[playerCombo].comboInput+" times!");
//		}
//		else{
//			print ("NEW COMBO ADDED!");
//			Combo newCombo = new Combo (playerCombo);
//			usedCombos.Add (newCombo);
//		}
		isIt = "Lenght?>"+correctLength+". Premade?>"+ premade+". New Combo?>"+usedAlready;
		return isIt;
	}

	public bool contains(string input, string[] list ){
		bool contained = false;

		for(int i = 0; i<list.Length-1;i++){
			if(list[i].Equals(input)){ contained = true; break;}
		}
		return contained;
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

	public	bool tooUsed(string combo, List<Combo> totalComboList, int prefUsage){
		bool usedMuch = false;
		int i = 0;
		foreach (Combo comBo in totalComboList){
			if(totalComboList[i].comboInput.Equals(combo) && totalComboList[i].usage>prefUsage){
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






