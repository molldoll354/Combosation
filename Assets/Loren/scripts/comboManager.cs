using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
[System.Serializable]
public class Combo {

	public string comboInput;//the literal string of characters that represenesnt the input
	public string comboName;//the name of the combo if it's premade, idk if necesary.

	public int usage;//how many times this has been used
	public int comboType ;//the type of combo this is, so the dialogue can be chosen. wchat = 0, aflatter =1, sjoke, = 2, dflirt 3, counter-clockwise.
	public int comboBonus ;//the bonus the combo gives.
	public bool isPremade;//is the combo premade.
	public bool unLocked;//is the combo unlocked

	public Combo (string inputCombo, string premadeName, int type, int bonus) {//premadeCombo COnstructor
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

		usage = 0;
		int randRange;
		int temp = (int)comboReader.Instance.CheckButtonCounts(inputCombo);
		if(temp ==0){
			randRange = (int)Random.Range (0, inputCombo.Length-1);
			comboType = inputCombo [randRange];
		}else{
			comboType = temp;
		}

		isPremade = false;
		unLocked = true;
		comboBonus = 1;
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
//	public GameObject discoveryPanel;
//	public Text discoveryBox;

	public string PlayerInput;
	public Combo inputCombo;
	public int preferedLenght;//what is the preferend length of combos for the date
	public int usageLimit;//how often a combo can be used before the date is upset.

	public string myJson;
	public Dictionary<string,Combo> dictionaryCombos = new Dictionary<string, Combo>();
	public Combo[] arrayOfCombos;

	// Use this for initialization
	void Start () {

		myJson = "Assets/Loren/scripts/premadeComboList.json";
	
		CreateListFromJson ();
		arrayOfCombos = new Combo[dictionaryCombos.Count];
		int i = 0;
		foreach( KeyValuePair<string, Combo> entryCombo in dictionaryCombos) {
			arrayOfCombos [i] = entryCombo.Value;
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetKeyDown(KeyCode.K)){
//			discoverOff ();
//		}
	}
//	public void discoverOff(){
//		discoveryBox.gameObject.SetActive (false);
//	}



	public int readCombo(string playerCombo){
		//Read Combo takes a string, the input of the player
		//return type of combo associated with that string.
		int typeOfCombo;

		//step 1
		//checks if there is a combo associated with that string in the dictionary. 
		//if there is, it should increase it's usage,
		//if not, it should add the string to the dictionary.
		if(dictionaryCombos.ContainsKey(playerCombo)){
			dictionaryCombos.TryGetValue (playerCombo, out inputCombo);
		}else{
			inputCombo = new Combo (playerCombo);
			dictionaryCombos.Add (playerCombo, inputCombo);

		}
		typeOfCombo = inputCombo.comboType;
		//step 2
		//chech it's usage,
		//if too often, respond with that.
		//if not too often, nothing. 
		Combo temp;
		dictionaryCombos.TryGetValue(playerCombo, out temp);
		if(temp.usage>usageLimit){
			typeOfCombo = 4;
		}
        
		return typeOfCombo;
	}

	public string displayDictionary(){
		/*
		 * create a string of combos
		 * if they have been discovered (usage == 0->1;)
		 * 	show their name, input and type
		 * if they haven't been
		 * 	show question marks
		 * 
		 */
		string TheDictionary = "\n#)_Name_____Input_____Type \n";
		int indexCombo = 0;
		foreach(Combo dictCombo in arrayOfCombos){
			

			string comboTypeString ="";//wchat = 0, aflatter =1, sjoke, = 2, dflirt 3

			if (dictCombo.usage > 0 ) {
				if (dictCombo.comboType == 0) {
					comboTypeString = "Chat";
				}else if(dictCombo.comboType ==1){
					comboTypeString ="Flatter";
				}else if(dictCombo.comboType ==2){
					comboTypeString ="Joke";
				}else if(dictCombo.comboType ==3){
					comboTypeString ="Flirt";
				}
				TheDictionary += indexCombo+") " + dictCombo.comboName + "     " + dictCombo.comboInput + "     " + comboTypeString+"\n";
			} else {
				TheDictionary += indexCombo+")-----\n";
			}
		}




		return TheDictionary;
	}


	private bool CreateListFromJson()
	{
		//catch in case it don't work
		try{
			//give us a place to store the next line of json
			string line;

			//create a reader to read the file
			StreamReader jsonReader = new StreamReader(myJson);

			using (jsonReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = jsonReader.ReadLine();

					if (line != null)
					{
						Combo newCombo = JsonUtility.FromJson<Combo>(line);
						dictionaryCombos.Add(newCombo.comboInput,newCombo);
					}
				}
				while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				jsonReader.Close();
				return true;
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (System.Exception e)
		{
			Debug.Log(e.Message);
			return false;
		}
	}


	public Combo addCombo(string playerCOmbo){
		Combo newCombo;

		if(dictionaryCombos.ContainsKey(playerCOmbo)){
			dictionaryCombos.TryGetValue (playerCOmbo, out newCombo);

			//inputCombo.increaseUsage ();
			//print ("new usage: " + inputCombo.usage);
		}else{
			inputCombo = new Combo (playerCOmbo);
			dictionaryCombos.Add (playerCOmbo, inputCombo);
			//
			newCombo = inputCombo;
		}
		return newCombo;
	}

}
