using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour {

    public UnityEngine.UI.Button button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseEnter()
    {
        
    }
    void OnMouseOver()
    {
        button.transform.localScale = new Vector3(4f, 4f, 1f);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Application.LoadLevel("Stage1");
    }
    void OnMouseExit()
    {
        button.transform.localScale = new Vector3(5f, 5f, 1f);
    }
}
