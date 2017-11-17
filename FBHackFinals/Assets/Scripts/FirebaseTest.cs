using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SaveIntoTable(string tableName, int score) {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl ("https://fbhackf-90483.firebaseio.com/");

		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

		DatabaseReference pushedRef = reference.Child (tableName).Push ();
		// replace with your favorite score omg!!
		// https://firebase.google.com/docs/database/unity/save-data
		// ^ look into function to save raw JSON if we want multiple fields
		pushedRef.SetValueAsync (score);
	}
}
