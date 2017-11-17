using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseModule3 : FirebaseTest {

	// Use this for initialization
	void Start () {
		//SaveScore (13);
	}

	// Update is called once per frame
	void Update () {

	}

	void SaveScore(int score) {
		base.SaveIntoTable ("module3", score);
	}
}
