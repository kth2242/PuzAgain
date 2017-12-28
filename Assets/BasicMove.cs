using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour {

    public float speed;
    Vector3 lookDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //    Debug.Log("Left Key is pressed");
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //    Debug.Log("Right Key is pressed");
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //    Debug.Log("Up Key is pressed");
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //    Debug.Log("Down Key is pressed");
        //}

        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S))
        {
            float xx = Input.GetAxisRaw("Vertical");
            float zz = Input.GetAxisRaw("Horizontal");
            lookDirection = xx * Vector3.forward + zz * Vector3.right;

            this.transform.rotation = Quaternion.LookRotation(lookDirection);
            this.transform.Rotate(90, 0, 0);
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
