using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseModule2 : FirebaseTest {

	// Use this for initialization
	void Start () {
		//SaveScore (12);
	}

	// Update is called once per frame
	void Update () {

	}

	void SaveScore(int score) {
		base.SaveIntoTable ("module2", score);
	}
}
