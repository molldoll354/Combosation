using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour {
	public int MaxButtons;
	public int ButtonsPressed;
	public float Timer = 11f;
	public Text timeText;
	public int friend;
	public int sad;
	public int love;

	// Use this for initialization
	void Start () {
		MaxButtons = 3;
	}
	
	// Update is called once per frame
	void Update () {
		//Mathf.Round (Timer);
		timeText.text = "Time: " + Mathf.Floor(Timer);
		if (Timer >= 0) {
			Timer-=Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
			ButtonsPressed++;
		}
		if (ButtonsPressed == MaxButtons) {
			Debug.Log ("You Did It!");
			//timeText.
		}
		if (Timer < 0 && ButtonsPressed < MaxButtons) {
			Debug.Log ("You dang fucked up son");
			timeText.text = "You Lose";
			//Timer = 0;
		}
	}
	//void FixedUpdate (){
		
	//}
}
