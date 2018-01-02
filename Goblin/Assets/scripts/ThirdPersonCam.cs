using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour {
    private const float ZOOM_MIN = -2f;
    private const float ZOOM_MAX = -12f;
    private const float Y_AXIS_MIN = 0f;
    private const float Y_AXIS_MAX = 70f;

    public Transform character;
    public Transform camTransform;

    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;

    private float zoom;
    public float zoomSpeed = 2f;

    public float smoothing = 2f;

	// Use this for initialization
	void Start ()
    {
        zoom = -5;
        mouseX += 180f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Update only if it is third person view
        if (this.GetComponent<Camera>().enabled)
        {
            zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

            if (zoom > ZOOM_MIN)
            {
                zoom = ZOOM_MIN;
            }
            else if (zoom < ZOOM_MAX)
            {
                zoom = ZOOM_MAX;
            }

            mouseX += Input.GetAxis("Mouse X");
            mouseY -= Input.GetAxis("Mouse Y");

            mouseY = Mathf.Clamp(mouseY, Y_AXIS_MIN, Y_AXIS_MAX);
   
            LookUpdate();
        }
        else
        {
            mouseX += Input.GetAxis("Mouse X")*2f;
            mouseY -= Input.GetAxis("Mouse Y");
        }
    }
    void LookUpdate()
    {
        //Looking direction
        Vector3 dir = new Vector3(character.rotation.x, 0, zoom);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

        camTransform.position = character.position + rotation * dir;
        camTransform.LookAt(character.position);
        character.transform.localRotation = Quaternion.AngleAxis(mouseX, character.transform.up);
    }
}
