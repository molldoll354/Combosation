using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCorrect : MonoBehaviour {

	public static string correctString;
	public Text Correct;
	public float timeToType;
	public static float textPercentage = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Correct.text = "" + correctString;
		int numberOfLettersToShow = (int)(correctString.Length * textPercentage);
		Correct.text = correctString.Substring (0, numberOfLettersToShow);
		textPercentage += Time.deltaTime / timeToType;
		textPercentage = Mathf.Min (1.0f, textPercentage);
	}
}
