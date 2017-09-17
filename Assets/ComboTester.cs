using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTester : MonoBehaviour {

	private ComboTest falconPunch= new ComboTest(new string[] {"down", "right","right"});
	//private ComboTest falconKick= new ComboTest(new string[] {"down", "right","Fire1"});

void Update () {
	if (falconPunch.Check())
	{
		// do the falcon punch
		Debug.Log("PUNCH"); 
	}		
	//if (falconKick.Check())
	//{
		// do the falcon punch
		//Debug.Log("KICK"); 
	//}
	}
}

