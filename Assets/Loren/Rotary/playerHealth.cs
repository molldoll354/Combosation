using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour {
	public int health=5;
	public Slider slidderVar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			health-=5;
			Debug.Log ("my health is" + health);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){
			health+=5;
			Debug.Log ("my health is" + health);
		}
		slidderVar.value = health;
	}
}
