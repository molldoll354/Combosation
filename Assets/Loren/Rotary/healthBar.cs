using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
	public GameObject player;
	public Slider sliderVar;
	// Use this for initialization
	void Start () {
		//sliderVar = GetComponent<healthBar> ();
	}
	
	// Update is called once per frame
	void Update () {
		sliderVar.value = player.GetComponent<playerHealth> ().health;
	}
}
