using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour
{
	public int MaxButtons;
	//max number of buttons needed to be pressed for this instance
	public int ButtonsPressed;
	//number of buttons that have been pressed
	public float Timer = 11f;
	//time players have to press buttons

	public Text timeText;
	//the timer text display
	public Text meterText;

	public float friend;
	//friend meter, max of 10
	public float sad;
	//sad meter, max of 10
	public float love;
	//love meter, max of 10
	public float DisplayFriend; //the ints the player see
	public float DisplaySad;
	public float DisplayLove;

	bool StopButtons; //determines whether the player can input stuff 

	public int sadUp, sadDown, loveUp, loveDown, friendUp, friendDown, sadness, friendliness, loveliness;
	public Slider sadnessBar,lovelyBar,friendlyBar;//sliders for the bars

	// Use this for initialization
	void Start ()
	{
		MaxButtons = 10;
		friend = 0f;
		sad = 10f;
		love = 0f;
		DisplayFriend = 0f;
		DisplaySad = 10f;
		DisplayLove = 0f;
		StopButtons = false;

		sadnessBar.GetComponent<sadBar> ().rateInc =sadUp;
		print (sadUp);
		sadnessBar.GetComponent<sadBar> ().rateDec = sadDown;
		lovelyBar.GetComponent<loveBar> ().rateInc =loveUp;
		lovelyBar.GetComponent<loveBar> ().rateDec = loveDown;
		friendlyBar.GetComponent<friendBar> ().rateInc =friendUp;
		friendlyBar.GetComponent<friendBar> ().rateDec =friendDown;

	}
	
	// Update is called once per frame
	void Update ()
	{
		friend = Mathf.Clamp (friend, 0f, 10f);
		sad = Mathf.Clamp (sad, 0f, 10f);
		love = Mathf.Clamp (love, 0f, 10f);
		DisplayFriend = Mathf.Clamp (DisplayFriend, 0f, 10f);
		DisplaySad = Mathf.Clamp (DisplaySad, 0f, 10f);
		DisplayLove = Mathf.Clamp (DisplayLove, 0f, 10f);


		Debug.Log ("" + StopButtons);
		meterText.text = "Sad: " + DisplaySad + "\nFriend: " + DisplayFriend + "\nLove: " + DisplayLove;
		//Mathf.Round (Timer);
		timeText.text = "Time: " + Mathf.Floor (Timer); //rounds the timer display so thta you dont see shitty decimals
		if (Timer >= 0) {
			
			Timer -= Time.deltaTime;
		}
		//if (StopButtons == false) {
		if (Input.GetKeyDown (KeyCode.W) && StopButtons == false) { //Chat. ups friend by 1, lowers love by 1, lowers sad by 1
			ButtonsPressed++;
			//friend++;
			//love--;
			//sad--;
			friendliness+=friendUp;
			loveliness -= loveDown;
			sadness -= sadDown;
		}
		if (Input.GetKeyDown (KeyCode.A) && StopButtons == false) { //Compliment. Ups love meter by 2, lowers sad by 1
			ButtonsPressed++;
			//love += 2;
			//sad--;
			loveliness+=loveUp*2;
			sadness -= sadDown;
		}

		if (Input.GetKeyDown (KeyCode.S) && StopButtons == false) { //Joke. Ups friend meter 2, lowers sad by 1
			ButtonsPressed++;
			//friend += 2;
			//sad--;
			friendliness+=friendUp;
			sadness -= friendDown;
		}

		if (Input.GetKeyDown (KeyCode.D) && StopButtons == false) { //Wink. Ups sad and love by 1
			ButtonsPressed++;
			//sad++;
			//love++;
			sadness+=sadUp;
			loveliness += loveUp;
			print ("im actually working");
		}

		if (ButtonsPressed >= MaxButtons) {
			Debug.Log ("You Did It!");
			Timer = 0;
			StopButtons = true;
			DisplayFriend = friend;
			DisplaySad = sad;
			DisplayLove = love;

			//timeText.
		}
		if (Timer < 0 && ButtonsPressed < MaxButtons) {
			Debug.Log ("You dang fucked up son");
			timeText.text = "You Lose";
			//Timer = 0;
		}
		//}
	}
	//void FixedUpdate (){
		
	//}
}
