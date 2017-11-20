using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newInput : MonoBehaviour {
	public string inputCombo="";



//	public GameObject happyFace, sadFace, loveFace;
//	public GameObject flatter, joke, wink, chat, neutral;
//	public Text meterText;
	public Text timeText;
	public Text iTExt;


	float Timer;
	public float TimerLength;

	int buttonSlotSelection = 0;


	public bool canPlayerSpeak = true;//controls when the player can input a combo
	public bool StopButtons;
	public bool resetSlots = false;
	public int preferedLength;
	public int maxUsage;//max usage of a combo before "overused"
	public Combo[] premadeCombos;
	List<Combo> comboUsage = new List<Combo> ();

	public Sprite blankSlotSprite; //sprites and array to control the button icons
	public Sprite flatterSlotSprite;
	public Sprite flirtSlotSprite;
	public Sprite chatSlotSprite;
	public Sprite jokeSlotSprite;
	public GameObject [] buttonSlots;	
	public soundScript audio;
	public AudioClip flatterSound;
	public AudioClip flirtSound;
	public AudioClip chatSound;
	public AudioClip jokeSound;
	public AudioClip music;

	int i = 8;
	int index=0;

	//Dictionary<string, int> comboUsage;
	// Use this for initialization
	void Start () {
		
		Timer = 8;

		audio.Play (music);
		canPlayerSpeak = true; 
	}
	
	// Update is called once per frame
	void Update () {

	
		Debug.Log (resetSlots);
		//Get player input. 
		if (canPlayerSpeak == true ) {
			if(inputCombo.Length < 5  && i ==1  )
			{
				if (Input.GetKeyDown (KeyCode.A)) {
					inputCombo += "A";
					audio.Play(flatterSound);
					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = flatterSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.W)) {
					inputCombo += "W";
					audio.Play(chatSound);
					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = chatSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.S)) {
					inputCombo += "S";
					audio.Play(jokeSound);
					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = jokeSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.D)) {
					inputCombo += "D";
					audio.Play(flirtSound);
					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = flirtSlotSprite;
					buttonSlotSelection++;
				}
			}

			if(Input.GetKeyDown(KeyCode.Space) ){
				
				if (i == 0) {
					print ("i is " + i);
					iTExt.text = "press space to talk";
					print ("call questions");
					GetComponent<comboReader> ().switchTextBoxes ();//this means we should initialize question off.
					GetComponent<comboReader> ().callQuestion ();
					i = 1;
				} else if (i == 1) {
					print ("i is " + i);
					iTExt.text = "press space to respond";
					resetSlots = true;
					//canPlayerSpeak = false;
					GetComponent<comboReader> ().readCombo (inputCombo);

					Timer = TimerLength;
					i = 2;

				} else if (i == 2) {
					print ("i is " + i);
					iTExt.text = "press space to hear next question";
					GetComponent<comboReader> ().switchTextBoxes ();
					i = 0;
					GetComponent<comboReader> ().callDialogue (GetComponent<comboManager> ().readCombo (inputCombo));
					inputCombo = "";
				} else if (i == 8) {//starts here.
					print ("i is " + i);
					iTExt.text = "press space to talk";
					GetComponent<comboReader> ().callQuestion ();
					i = 1;
				}

				
			}

		}
		else { 
			if(Input.GetKeyDown(KeyCode.Space) && canPlayerSpeak == false){ 
				resetSlots = true;

				timeText.text = "" + Mathf.Floor (Timer);
				Timer = TimerLength;
				inputCombo = "";

			}
		}

		if (resetSlots == true) {
			buttonSlots [0].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlots [1].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlots [2].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlots [3].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlots [4].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlotSelection = 0;
			resetSlots = false;
		}

		timeText.text = "" + Mathf.Floor (Timer);

		if (Timer >= 0) {
			Timer -= Time.deltaTime;
		}
		if (Timer < 0) {
			timeText.text = "0";
			canPlayerSpeak = false;
			GetComponent<comboReader> ().readCombo ("");
			print (""+inputCombo);
		}
	}

}






