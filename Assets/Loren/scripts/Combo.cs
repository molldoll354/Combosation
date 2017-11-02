using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo {


		public string comboInput {get;set;}
		//public string premadeCombo{get;set;}//the name of the combo if it's premade, idk if necesary.
		public int usage{get;set;}
		public int friendChangePos{get;set;}
		public int friendChangeNeg{get;set;}
		public int loveChangePos{get;set;}
		public int loveChangeNeg{get;set;}

		public Combo (string combo, int friendPos, int friendNeg, int lovePos, int loveNeg){
			comboInput = combo;
			usage = 0;
			friendChangePos = friendPos; friendChangeNeg = friendNeg; 
			loveChangePos = lovePos; loveChangeNeg=loveNeg;

		}
		public Combo(string combo){
		comboInput = combo;
		usage = 0;

			//cop even's code to sort out it what the value is
		}


	}
