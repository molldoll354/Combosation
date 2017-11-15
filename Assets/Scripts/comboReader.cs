using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SakiAnswer{
	public List<string> options;
	public List<int> moodEffect;
}

public class comboReader : MonoBehaviour {
	public comboManager comboManage;

	private static comboReader _instance;

	public static comboReader Instance { get { return _instance; } }

	enum buttonType{W = 0, A = 1, S = 2, D = 3, Tie = 4};

	public string Source;

	List <int> buttonCount;

	public List<string> questions;
	public List<SakiAnswer> responses;
	public int questionIndex =0;
	public int finalAnswer =0;

	public int statChecker;//checks mood over time going from sad to happy
	public int chatChecker, flatterChecker, flirtChecker, jokeChecker;

	public Text dialogueText;
	public Text questionText;
	//public bool canPlayerSpeak = true;
	// Use this for initialization

	public GameObject saki;
	public Animator sakiAnim;
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
		//Debug.Log (questions [questionIndex]);
		GetComponent<newInput> ().canPlayerSpeak = true;
		//		buttonType mostPressedButton = CheckButtonCounts (Source);
		//responses [questionIndex].options [(int)mostPressedButton];
		//buttonType mostPressedButton = CheckButtonCounts (Source);
		statChecker=0;
		sakiAnim = saki.GetComponent<Animator> ();
	}
	/*
	 * same object as game master
	 * if (comboManager.readCombo(Source) == 0) {
					statChecker += 1;//check the dialogue document and see what responses are marked 1,2,3 or 4
					chatChecker += 1;
				}
	 * 
	 */ 



	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("dellapisoundscene");
		}

//		if (Input.GetKeyDown (KeyCode.P)) {
//			gameObject.SetActive(false);
//		}
//		Debug.Log ("noPress");
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			Debug.Log (responses [questionIndex].options [(int)CheckButtonCounts(Source)]);//pull the button type into responseops
//			questionIndex++;
//			Debug.Log (questions [questionIndex]);
	
//		}//molly check here for animator work
		if (!Input.GetKeyDown (KeyCode.Space)&&questionIndex!=9) {
			questionText.text = questions [questionIndex];
		}
		/*if (chatChecker > jokeChecker && chatChecker > flirtChecker && chatChecker > flatterChecker) {
			Debug.Log("neutral");
			saki.GetComponent<Animator> ().Play ("neutral");
		}
		if (jokeChecker > chatChecker && jokeChecker > flirtChecker && jokeChecker > flatterChecker) {
			Debug.Log("laughing");
			saki.GetComponent<Animator> ().Play ("laughing");
		}
		if (flatterChecker > jokeChecker && flatterChecker > flirtChecker && flatterChecker > chatChecker) {
			Debug.Log("blushing");
			saki.GetComponent<Animator> ().Play ("happy");
		}
		if (flirtChecker > jokeChecker && flirtChecker > chatChecker && flirtChecker > flatterChecker) {
			Debug.Log("heart eyes");
			saki.GetComponent<Animator> ().Play ("blush");
		}*/
		saki.GetComponent<Animator> ().SetFloat ("BaseMood", statChecker);//molly check here for animator work

	}

	public void readCombo(string Source){
		//Debug.Log("Reader"+Source);
		Debug.Log (statChecker);
		print (Source);
			//print ("in b4 Source=Getblabblab");
			//Source = GetComponent<newInput> ().inputCombo;
			//print ("" + questionIndex+" vs "+responses.Count);
			//Debug.Log ("welcome" +responses [questionIndex].options [(int)CheckButtonCounts(Source)]);//pull the button type into responseops

			dialogueText.text = responses [questionIndex].options [(int)CheckButtonCounts (Source)];
		
			//print("b4 questionIndex++");
			questionIndex++;
			if(questionIndex < questions.Count){
				
				//Debug.Log (questions [questionIndex]);
			} else {
				print("convo ended");
			}
			//print("b4 getcomponnent<>.playercanspeak=true");
			GetComponent<newInput> ().inputCombo = "";
			GetComponent<newInput> ().canPlayerSpeak = true;


			if(questionIndex==0){//evan start here
				//Debug.Log("Update"+Source);
			if ((int)CheckButtonCounts (Source) == 0) {
				statChecker += 1;//check the dialogue document and see what responses are marked 1,2,3 or 4
				chatChecker += 1;
			}
			if((int)CheckButtonCounts(Source)==1){
				statChecker += 0;//depending on what number is there, change the stat checker value accordingly
				flatterChecker += 1;

				}
			if((int)CheckButtonCounts(Source)==2)
					{
				statChecker += 2;//make sure that the order of "buttons" is always chat, flatter, joke, flirt
				jokeChecker += 1;	
				sakiAnim.Play ("laughingREACT");

				}
			if((int)CheckButtonCounts(Source)==3){
				statChecker += -1;//make sure chat/flatter/joke/flirt values are always set to +=1
				flirtChecker += 1;

					}
			}
		if(questionIndex==1){
				//Debug.Log("Update"+Source);
				if ((int)CheckButtonCounts (Source) == 0) {
				RespondChat ();
				}
				if((int)CheckButtonCounts(Source)==1){
				RespondFlatter ();

				}
				if((int)CheckButtonCounts(Source)==2)
				{
				RespondJoke ();

				}
				if((int)CheckButtonCounts(Source)==3){
				RespondFlirt ();
				}
			}
			if(questionIndex==2){
				//Debug.Log("Update"+Source);
				if ((int)CheckButtonCounts (Source) == 0) {
					statChecker += 1;
					chatChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==1){
					statChecker += 2;
					flatterChecker += 1;

				}
				if((int)CheckButtonCounts(Source)==2)
				{
					statChecker += -1;
					jokeChecker += 1;

				}
				if((int)CheckButtonCounts(Source)==3){
					statChecker += 0;
					flirtChecker += 1;
				}
			}
			if(questionIndex==3){
				//Debug.Log("Update"+Source);
				if ((int)CheckButtonCounts (Source) == 0) {
					statChecker += 0;
					chatChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==1){
					statChecker += 2;
					flatterChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==2)
				{
					statChecker += 1;
					jokeChecker += 1;

				}
				if((int)CheckButtonCounts(Source)==3){
					statChecker += -1;
					flirtChecker += 1;
				}
			}
			if(questionIndex==4){
				//Debug.Log("Update"+Source);
				if ((int)CheckButtonCounts (Source) == 0) {
					statChecker += 1;
					chatChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==1){
					statChecker += 2;
					flatterChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==2)
				{
					statChecker += 0;
					jokeChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==3){
					statChecker += -1;
					flirtChecker += 1;
				}
			}
			if(questionIndex==5){
				//Debug.Log("Update"+Source);
				if ((int)CheckButtonCounts (Source) == 0) {
					statChecker += 0;
					chatChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==1){
					statChecker += 0;
					flatterChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==2)
				{
					statChecker += 0;
					jokeChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==3){
					statChecker += 0;
					flirtChecker += 1;
				}
			}


			if(questionIndex==6){
				//Debug.Log("Update"+Source);
				if ((int)CheckButtonCounts (Source) == 0) {
					statChecker += 0;
					chatChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==1){
					statChecker += 1;
					flatterChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==2)
				{
					statChecker += -1;
					jokeChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==3){
					statChecker += 2;
					flirtChecker += 1;
				}
			}
			if(questionIndex==7){
				//Debug.Log("Update"+Source);
				if ((int)CheckButtonCounts (Source) == 0) {
					statChecker += -1;
					chatChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==1){
					statChecker += 1;
					flatterChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==2)
				{
					statChecker += 0;
					flirtChecker += 1;

				}
				if((int)CheckButtonCounts(Source)==3){

					statChecker += 2;
					jokeChecker += 1;
				}
			}
			if(questionIndex==8){
				//Debug.Log("Update"+Source);
				if ((int)CheckButtonCounts (Source) == 0) {
					statChecker += -1;
					chatChecker += 1;
				}
				if((int)CheckButtonCounts(Source)==1){
					statChecker += 1;
					flatterChecker += 1;

				}
				if((int)CheckButtonCounts(Source)==2)
				{
					statChecker += 0;
					jokeChecker += 1;

				}
				if((int)CheckButtonCounts(Source)==3){
					statChecker += 2;
					flirtChecker += 1;
				}
			}
			if (questionIndex == 9) {
				if (statChecker >= 16) {
					dialogueText.text = "Combosation Grade:";
					questionText.text = "S+ ! You're a dating master!";
				}
				if (statChecker>=10 && statChecker<16) {
					dialogueText.text = "Combosation Grade:";
					questionText.text= "A! You did great! Have fun on the date!";
				}
				if (statChecker >= 4 && statChecker < 10) {
					dialogueText.text = "Combosation Grade:";
					questionText.text = "B! Could be worse, but she likes you!";
				}
				if(statChecker>=-2 && statChecker < 4){
					dialogueText.text = "Combosation Grade:";
					questionText.text = "D! This is gonna be a weird date!";
				}
				if (statChecker >= -8 && statChecker<-2 ) {
					dialogueText.text = "Combosation Grade:";
					questionText.text = "F- ! Yikes! You're terrible!";
				}
			}

	}

	void RespondJoke(){
		statChecker += responses [questionIndex].moodEffect [2];
		jokeChecker += 1;
		sakiAnim.Play ("laughingREACT");
	}
	void RespondFlatter(){
		statChecker += responses [questionIndex].moodEffect [1];
		flatterChecker += 1;
	}

	void RespondFlirt(){
		statChecker += responses [questionIndex].moodEffect [3];
		flirtChecker += 1;
	}

	void RespondChat(){
		statChecker+=responses[questionIndex].moodEffect[0];
		chatChecker+=1;
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

		return (ResponseOps)largestButtonType;
	}

}
