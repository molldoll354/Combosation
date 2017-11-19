using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

	public string myJson;
	Dictionary<string,Combo> dictionaryCombos = new Dictionary<string, Combo>();


	// Use this for initialization
	void Start () {
//		Combo combo1 = new Combo ("ASA", "wholesome", 2, 1 ); //1, 2, 1, 0, 2, 2);
//		Combo combo2 = new Combo ("WWSS","standup special", 2,1);//4, 3, 0,0,1,2 );
//		Combo combo3 = new Combo ("DSSWD", "smooth criminal",1,1);
//		dictionaryCombos.Add (combo1.comboInput, combo1);
//		dictionaryCombos.Add (combo2.comboInput, combo2);
//		dictionaryCombos.Add (combo3.comboInput, combo3); 	

		myJson = "Assets/Loren/scripts/premadeComboList.json";
	
		CreateListFromJson ();
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
		Combo temp;
		dictionaryCombos.TryGetValue(playerCombo, out temp);
		if(temp.usage>usageLimit){
			comboType = 4;
		}
        

		return comboType;
	}

	public void displayDictionary(){
		
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


}
