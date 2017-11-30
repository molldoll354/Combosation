﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SakiAnswer{
	public List<string> options;//number of options that the player has
	public List<int> moodEffect;//int in the inspector that goes up or down depending on how appropriate the response is 
}




public class comboReader : MonoBehaviour {
	public comboManager comboManage;
	//public newInput newInput;
	public Dictionary<string, Combo> comboDictionary = new Dictionary<string, Combo>();
	private static comboReader _instance;

	public static comboReader Instance { get { return _instance; } }

	enum buttonType{W = 0, A = 1, S = 2, D = 3, Tie = 4};

	public string Source;

	List <int> buttonCount;

	public List<string> questions;//the actual questions that Saki asks
	public List<SakiAnswer> responses;//Saki's responses (both this and the questions are stored in the inspector) 
	public int questionIndex =0;//determines what number question you're on 
	public int finalAnswer =0;

	public static int statChecker;//checks mood over time going from sad to happy
	public int chatChecker, flatterChecker, flirtChecker, jokeChecker;//checks the number of times each type of combo has been used throughout conversation

	public Text comboDescriptor;
	public Text dialogueText;//displays response text
	public Text questionText;//displays question text
	//public bool canPlayerSpeak = true;
	// Use this for initialization
	public GameObject sakiBubble;
	public Sprite neutralBubble;
	public Sprite goodBubble1;
	public Sprite goodBubble2;
	public Sprite badBubble1;
	public Sprite badBubble2;

	public AudioSource annoyanceSounds;
	public AudioSource newComboSource;
	public AudioClip annoyanceUp;
	public AudioClip annoyanceDown;

	int statEffect;
	public Combo currentCombo;

	public float annoyanceCounter;
	public GameObject saki;
	public Animator sakiAnim;//Saki's animator
	public enum ResponseOps{//converts strings to ints
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
		//Debug.Log (questions [questionIndex]);
		comboDictionary= GetComponent<comboManager>().dictionaryCombos;
		GetComponent<newInput> ().canPlayerSpeak = true;


		statChecker=10;
		sakiAnim = saki.GetComponent<Animator> ();
	}
		
	// Update is called once per frame
	void Update () {

		if (annoyanceCounter == 3) {
			statChecker = -30;
			questionIndex = 9;
		}

		/*
		 * 
		 * int i = 0
		 * get space key
		 * 		if(i = 0){
		 * 			call question;
		 * 			i++;}
		 * 		if(i=1){ readCombo;i++}
		 * 		if(i=2){call response, i = 0}
		 * 
		 * 
		 */
		if (questionIndex == 9) {
			//Application.LoadLevel ("EndingScene");
			Application.LoadLevel(3);
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			//Application.LoadLevel ("dellapisoundscene");//reloads game
		}

		if (statChecker > 55) { 
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = goodBubble2;
		}
		if (statChecker > 30 && statChecker <= 55) { //this stuff changes her bubble depending on how well you're doing
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = goodBubble1;
		}
		if (statChecker <= 30 && statChecker > 0) {
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = neutralBubble;

		}
		if (statChecker <= 0 && statChecker > -12) {
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = badBubble1;

		}
		if (statChecker <= -12) {
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = badBubble2;

		}
			
	
//		}//molly check here for animator work
//		if (!Input.GetKeyDown (KeyCode.Space)) {
//			questionText.text = questions [questionIndex];//question text displays based on what number question you're on
//		}
	
		saki.GetComponent<Animator> ().SetFloat ("BaseMood", statChecker);//molly check here for animator work

	}

	public void switchTextBoxes(){//A=Question, b= dialogue
		if(questionText.gameObject.activeInHierarchy ==true){
			questionText.gameObject.SetActive(false);
			dialogueText.gameObject.SetActive(true);
		}
		else{
			questionText.gameObject.SetActive(true);
			dialogueText.gameObject.SetActive(false);
		}
	}

	public void readCombo(string Source){
		
		//Debug.Log("Reader"+Source);
		//Debug.Log ("statchecker"+statChecker);
		print (Source);
		Combo temp = GetComponent<comboManager> ().addCombo (Source);
		currentCombo = temp;
		int currentComboType = GetComponent<comboManager>().readCombo (Source);
		Debug.Log ("the manager returned " + currentComboType);
		if (temp.isPremade == true) {
			comboDescriptor.text = 
				"NEW DISCOVERY" +//I know it's bad english
				"\nNew Combo: "+ temp.comboInput + 
				"\n\""+temp.comboName+ "\"" + 
				"\n Type: " + temp.comboType+" Bonus: "+temp.comboBonus+"X";

			newComboSource.Play ();
			/*
			 *Play sound/animation here?
			 */ 

		} else {
			comboDescriptor.text = "";
		}
	
		    //switchTextBoxes();
		//dialogueText.text = responses [questionIndex].options [currentComboType];//takes the most pressed button, converts it to an int, then displays a response based on what that int is
		
			//print("b4 questionIndex++");
			
			
			GetComponent<newInput> ().inputCombo = "";
			GetComponent<newInput> ().canPlayerSpeak = true;

		print("save me lord" + questionIndex);


				//Debug.Log("Update"+Source);
		if (currentComboType == 0) {//checks if a chat combo was pressed
				RespondChat ();//calls chat function
			if (temp.isPremade == false) {
				if (statEffect > 0) {
					comboDescriptor.text = "Chat! +" + Mathf.Abs (statEffect);
				} else {
					comboDescriptor.text = "Chat?! -" + Mathf.Abs (statEffect);
				}
			}
			questionIndex++;//moves the question index along
				}
		if(currentComboType==1){//checks for flatter
				RespondFlatter ();
			if (temp.isPremade == false) {
				if (statEffect > 0) {
					comboDescriptor.text = "Flatter! +" + Mathf.Abs (statEffect);
				} else {
					comboDescriptor.text = "Flatter?! -" + Mathf.Abs (statEffect);
				}
			}
			questionIndex++;
				}
		if(currentComboType==2)
				{
				RespondJoke ();
			if (temp.isPremade == false) {
				if (statEffect > 0) {
					comboDescriptor.text = "Joke! +" + Mathf.Abs (statEffect);
				} else {
					comboDescriptor.text = "Joke?! -" + Mathf.Abs (statEffect);
				}
			}
			questionIndex++;
				}
		if (currentComboType == 3) {
			RespondFlirt ();
			if (temp.isPremade == false) {
				if (statEffect > 0) {
					comboDescriptor.text = "Flirt! +" + Mathf.Abs (statEffect);
				} else {
					comboDescriptor.text = "Flirt?! -" + Mathf.Abs (statEffect);
				}
				questionIndex++;
			}
		}
		if (currentComboType == 4) {
			RespondAnnoyed ();
			questionIndex++;
		}

	}
	public void callDialogue(int typeOfCombo){
		dialogueText.text = responses [questionIndex].options [typeOfCombo];//takes the most pressed button, converts it to an int, then displays a response based on what that int is

	}

	public void callQuestion(){
		questionText.text = questions [questionIndex];//question text displays based on what number question you're on

	}
	void RespondAnnoyed(){
		int statEffect = responses[questionIndex].moodEffect[4];
		sakiAnim.Play("unimpressedREACT");
		annoyanceCounter++;
		annoyanceSounds.clip = annoyanceUp;
		annoyanceSounds.Play ();
	}
	void RespondJoke(){
		if(statChecker>0){
		 statEffect = responses [questionIndex].moodEffect [2];//checks the mood effect int in the inspector
		}
		if ((statChecker < 0) || annoyanceCounter > 0) {
			statEffect = -1;
		}
		if (statEffect == 2 && annoyanceCounter > 0) {
			annoyanceCounter--;
			annoyanceSounds.clip = annoyanceDown;
			annoyanceSounds.Play ();
		}
		statChecker += (statEffect*currentCombo.comboBonus)+1;//increases statchecker based on what was found in mood effect
		jokeChecker += 1;
		if (statEffect == -2) {
			annoyanceCounter++;
			annoyanceSounds.clip = annoyanceUp;
			annoyanceSounds.Play ();
		}
		if (statEffect <= 0) {
			sakiAnim.Play ("unimpressedREACT");
		}
		if (statEffect == 1) {
			sakiAnim.Play ("happyREACT");
		}
		if (statEffect == 2) {
			sakiAnim.Play ("laughingREACT");
		}
	}
	void RespondFlatter(){
		if(statChecker>0){
			statEffect = responses [questionIndex].moodEffect [1];//checks the mood effect int in the inspector
		}
		if ((statChecker < 0) || annoyanceCounter > 0) {
			statEffect = -2;
		}
		if (statEffect == 2 && annoyanceCounter > 0) {
			annoyanceCounter--;
			annoyanceSounds.clip = annoyanceDown;
			annoyanceSounds.Play ();
		}
		//int statEffect = responses [questionIndex].moodEffect [1];
		statChecker += (statEffect * currentCombo.comboBonus)+1;
		flatterChecker += 1;
		if (statEffect == -2) {
			annoyanceCounter++;
			annoyanceSounds.clip = annoyanceUp;
			annoyanceSounds.Play ();
		}
		if (statEffect <= 0) {
			sakiAnim.Play ("unimpressedREACT");
		}
		if (statEffect == 1) {
			sakiAnim.Play ("happyREACT");
		}
		if (statEffect == 2) {
			sakiAnim.Play ("loveREACT");
		}
	}

	void RespondFlirt(){
		if(statChecker>=0){
			statEffect = responses [questionIndex].moodEffect [3];//checks the mood effect int in the inspector
		}
		if ((statChecker < 0) || annoyanceCounter > 0) {
			statEffect = -2;
		}
		if (statEffect == 2 && annoyanceCounter > 0) {
			annoyanceCounter--;
			annoyanceSounds.clip = annoyanceDown;
			annoyanceSounds.Play ();
		}
		//int statEffect = responses [questionIndex].moodEffect [3];
		statChecker += (statEffect* currentCombo.comboBonus)+1;
		//maximum per statchecker is 9, minimum is -7
		flirtChecker += 1;
		if (statEffect == -2) {
			annoyanceCounter++;
			annoyanceSounds.clip = annoyanceUp;
			annoyanceSounds.Play ();
		}
		if (statEffect <= 0) {
			sakiAnim.Play ("angryREACT");
		}
		if (statEffect == 1) {
			sakiAnim.Play ("laughingREACT");
		}
		if (statEffect == 2) {
			sakiAnim.Play ("loveREACT");
		}
	}

	void RespondChat(){
		
			statEffect = responses [questionIndex].moodEffect [0];//checks the mood effect int in the inspector
		
//		if ((statChecker < 0) || annoyanceCounter > 0) {
//			statEffect = -2;
//		}
//		if (statEffect == 2 && annoyanceCounter > 0) {
//			annoyanceCounter--;
//			annoyanceSounds.clip = annoyanceDown;
//			annoyanceSounds.Play ();
//		}
		//int statEffect = responses[questionIndex].moodEffect[0];
		statChecker += (statEffect* currentCombo.comboBonus)+1;
		chatChecker+=1;
		if (statEffect == -2) {
			annoyanceCounter++;
			annoyanceSounds.clip = annoyanceUp;
			annoyanceSounds.Play ();
		}
		if (statEffect <= 0) {
			sakiAnim.Play ("unimpressedREACT");
		}
		if (statEffect == 1) {
			sakiAnim.Play ("neutralREACT");
		}
		if (statEffect == 2) {
			sakiAnim.Play ("happyREACT");
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
			

		return (ResponseOps)largestButtonType;
	}

}
