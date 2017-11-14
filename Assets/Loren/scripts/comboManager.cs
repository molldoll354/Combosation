using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo {
	public string comboInput {get;set;}//the literal string of characters that represenesnt the input
	public string comboName{get;set;}//the name of the combo if it's premade, idk if necesary.
	public string comboResponse{get;set;} //the response Saki gives for this premade combo.
	public int usage{get;set;} //how many times this has been used
	public int comboType {get;set;}//the type of combo this is, so the dialogue can be chosen.
	public int comboBonus {get;set;}//the bonus the combo gives.
	public bool isPremade{get;set;}//is the combo premade.
	public bool unLocked{get;set;}//is the combo unlocked

	public Combo (string inputCombo, string premadeName, int type, string dialogueResponse, int bonus) {//premadeCombo COnstructor
		comboInput = inputCombo; 
		comboName = premadeName; 
		usage = 0;
		comboType = type;
		comboBonus = bonus;
		isPremade = true;
		unLocked = true;
	}
	public Combo (string inputCombo){//randomCombo constructor
		comboInput = inputCombo; 
		comboName = "random";
		comboResponse = "";
		usage = 0;
		comboType = (int)comboReader.Instance.CheckButtonCounts(inputCombo);
		isPremade = false;
		unLocked = true;
	}
	public void increaseUsage()
	{
		usage++;
	}
	public string toString(){
		string info = "Name: "+comboName+"| Combo:"+comboInput+"| Type:" +comboType+"| Used: "+usage+"| Bonus:"+comboBonus;

		return info;
	}
	public int addBonus(int answerPoints ){
		int newPoints = answerPoints + comboBonus;
		return newPoints;
	}
	public int multBonus(int answerPoints){
		int newPoints = answerPoints * comboBonus;
		return newPoints;
	}


}
public class comboManager : MonoBehaviour {
	public string PlayerInput;
	public Combo inputCombo;
	public int preferedLenght;//what is the preferend length of combos for the date
	public int usageLimit;//how often a combo can be used before the date is upset.

	Dictionary<string,Combo> dictionaryCombos = new Dictionary<string, Combo>();
	// Use this for initialization
	void Start () {
		Combo combo1 = new Combo ("ASA", "wholesome", 2, "", 1 ); //1, 2, 1, 0, 2, 2);
		Combo combo2 = new Combo ("WWSS","standup special", 2,"",1);//4, 3, 0,0,1,2 );
		Combo combo3 = new Combo ("DSSWD", "smooth criminal",1,"",1);
		dictionaryCombos.Add (combo1.comboInput, combo1);
		dictionaryCombos.Add (combo2.comboInput, combo2);
		dictionaryCombos.Add (combo3.comboInput, combo3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}




	public int readCombo(string playerCombo){
		//Read Combo takes a string, 
		//return type of combo associated with that string.
		int comboType = 0;

		//step 1
		//checks if there is a combo associated with that string in the dictionary. 
		//if there is, it should increase it's usage,
		//if not, it should add the string to the dictionary.
		if(dictionaryCombos.ContainsKey(playerCombo)){
			dictionaryCombos.TryGetValue (playerCombo, out inputCombo);
			print ("current usage: " + inputCombo.usage);
			inputCombo.increaseUsage ();
			print ("new usage: " + inputCombo.usage);
		}else{
			dictionaryCombos.Add (playerCombo, inputCombo);
			print ("NEW COMBO USED:" + playerCombo); 
		}

		//step 2
		//chech it's usage,
		//if too often, respond with that.
		//if not too often, nothing. 
		if(dictionaryCombos>usageLimit){//how do I access specific element in the dictionary? primarily, how do I get usage of a newly added combo? I did not test for premade combos.
			comboType = 8;
			print ("USED TOO OFTEN! USED TOO OFTEN! USED TOO OFTEN! USED TOO OFTEN! USED TOO OFTEN!");
		}

		//step 3
		//check it's length, 
		//if too long, respond with that. MEaning change what ever is the response to the preset ones.
		//if not too long, nothing.
		if(playerCombo.Length>preferedLenght){
			comboType = 16;
			print ("TOOOOOOOOOOOO LLLLOOOOOOOOOOOOOOOOOOONNNNNNNNNNNNNG");

		}

		return comboType;
	}





	public bool tooLong(){
		bool length = false;
		if(PlayerInput.Length>preferedLenght){length = true;}
		return length;
	}

	public bool usedOften(){
		bool often=false;
		if (dictionaryCombos.ContainsKey (PlayerInput)) {
			Combo temp;
			dictionaryCombos.TryGetValue (PlayerInput, out temp);
			int usedness = temp.usage;
			if (usedness > usageLimit) {
				often = true;
			}
		}else{
			print("combo has not been used before.");
		}
		return often;
	}

	public Combo addCombo(){
		//does contain.blah blah blah.
		Combo temp;
		if( dictionaryCombos.ContainsKey(PlayerInput)==true){
			dictionaryCombos.TryGetValue (PlayerInput, out temp);
		}
		else{
			temp = new Combo (PlayerInput);

		}
		return temp;
	}





}
