using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDate : MonoBehaviour {
	public GameObject player;

	//ints for when the time is started, how long the time goes, what "question" the date asked, the answer the player gave
	public float timerInitiated,timerLength, question, response;
	public bool dateSpeaking = true, playerSpeaking=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			this.generateQuestion ();
		}

	}


	public float generateQuestion(){
		question = Random.Range (1f, 3f);
		Debug.Log("What's the luckiest number?");
		return question;

	}

	public void interpretResponse(int response){
		if(response==question){
			Debug.Log ("I'm glad you agree.");
		}
		else{
			Debug.Log ("I'm sorry to hear you're wrong. The number \"+question+\" is the luckiest and that's a rock fact");
		}
	}
}
