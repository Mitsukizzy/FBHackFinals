using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActions : MonoBehaviour {

    private Animation anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grow()
    {
        anim.Play();
    }

    public void Shrink()
    {
        anim.Play("BoxShrink");
    }
}
