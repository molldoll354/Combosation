using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboFlavor : MonoBehaviour {

	public comboReader comboReader;
	public comboManager comboManager;
	int bigMood;
	// Use this for initialization
	void Start () {
		bigMood = (int)comboReader.responses [questionIndex].moodEffect;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
