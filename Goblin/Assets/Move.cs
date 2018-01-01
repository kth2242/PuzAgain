using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	private Animator anim;
	private float speed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W))
		{
			speed = 1f;
			anim.SetFloat ("speed", speed);
		}
		else
		{
			speed = 0f;
			anim.SetFloat ("speed", speed);
		}
	}
}
