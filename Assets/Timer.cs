using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public float totalTime = 60f;
    private int showTime = 0;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        showTime = (int)totalTime;
        totalTime -= Time.deltaTime;

        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Time Left : " + showTime.ToString();
    }
}
