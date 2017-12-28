using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float Power = 200f;
    public float Range = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, this.transform.up * Range, Color.red);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.up, out hit, Range))
            {
                Debug.Log("shoot");
                if (hit.collider.gameObject.tag == "Cube")
                {
                    
                    hit.rigidbody.AddForceAtPosition(transform.up * Power, hit.point);
                }
            }
        }
	}
}
