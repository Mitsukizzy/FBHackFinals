﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseModule1 : FirebaseTest {

	// Use this for initialization
	void Start () {
		SaveScore (539);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveScore(int score) {
		base.SaveIntoTable ("module1", score);
	}
}
