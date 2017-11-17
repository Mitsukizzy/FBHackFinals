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

    public void OnPointerEnter()
    {
        anim.Play();
    }

    public void OnPointerExit()
    {
        anim.Play("BoxShrink");
    }
}
