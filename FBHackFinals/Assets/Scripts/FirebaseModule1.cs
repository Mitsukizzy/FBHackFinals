using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseModule1 : FirebaseTest {

	// Use this for initialization
	void Start () {
		//SaveScore (11);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SaveScore(int score) {
		base.SaveIntoTable ("module1", score);
	}
}
