using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endSceneFinal : MonoBehaviour {

	public GameObject grade;
	public GameObject medal;

	public Sprite S;
	public Sprite A;
	public Sprite B;
	public Sprite C;
	public Sprite D;
	public Sprite F;
	public Sprite chatMedal;
	public Sprite flatterMedal;
	public Sprite flirtMedal;
	public Sprite jokeMedal;

	public Text gradeText;
	public Text medalText;
	public Text textText;

	float gradeTimer = .75f;
	float medalTimer = 1.25f;
	float textTimer = 1.75f;

	bool gradeSet;
	bool medalSet;
	bool textSet;

	// Use this for initialization
	void Start () {

		comboReader.statChecker = 60;


	}
	
	// Update is called once per frame
	void Update () {
		gradeTimer -= Time.deltaTime;
		medalTimer -= Time.deltaTime;
		textTimer -= Time.deltaTime;

		if (gradeTimer <= 0 && gradeSet == false) {
			if (comboReader.statChecker <= -24) {
				//F RANK
				grade.GetComponent<SpriteRenderer> ().sprite = F;
				gradeText.text = "You got an F!  Ouch...";

			}
			if (comboReader.statChecker > -24 && comboReader.statChecker <= 9) {
				//D RANK
				grade.GetComponent<SpriteRenderer> ().sprite = D;
				gradeText.text = "You got a D!  You need some practice.";
			}
			if (comboReader.statChecker > 8 && comboReader.statChecker <= 24) {
				//C RANK
				grade.GetComponent<SpriteRenderer> ().sprite = C;
				gradeText.text = "You got a C!  Could be worse.";
			}
			if (comboReader.statChecker > 24 && comboReader.statChecker <= 40) {
				//B RANK
				grade.GetComponent<SpriteRenderer> ().sprite = B;
				gradeText.text = "You got a B!      Not bad.";
			}
			if (comboReader.statChecker > 40 && comboReader.statChecker <= 56) {
				//A RANK
				grade.GetComponent<SpriteRenderer> ().sprite = A;
				gradeText.text = "You got an A!  Great job!";
			}
			if (comboReader.statChecker > 56 && comboReader.statChecker <= 72) {
				//S RANK
				grade.GetComponent<SpriteRenderer> ().sprite = S;
				gradeText.text = "You got an S!  That's amazing!";
			}
		}
	}
}
