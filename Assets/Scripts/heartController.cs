using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour {

	public comboReader comboReader;
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (comboReader.GetComponent<comboReader> ().annoyanceCounter == 1) {
			
		}
	}
}
