using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Camera firstViewCam;
    [SerializeField]
    Camera thirdViewCam;

    private bool isFirstViewPoint = true;
    
    // Use this for initialization
    void Start ()
    {
        firstViewCam.GetComponent<Camera>().enabled = true;
        thirdViewCam.GetComponent<Camera>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown("p"))
        {
            isFirstViewPoint = !isFirstViewPoint;
        }

        if(isFirstViewPoint)
        {
            FirstViewCamOn();
        }
        else
        {
            ThirdViewCamOn();
        }
	}

    void FirstViewCamOn()
    {
        firstViewCam.GetComponent<Camera>().enabled = true;
        thirdViewCam.GetComponent<Camera>().enabled = false;
    }

    void ThirdViewCamOn()
    {
        firstViewCam.GetComponent<Camera>().enabled = false;
        thirdViewCam.GetComponent<Camera>().enabled = true;
    }
}
