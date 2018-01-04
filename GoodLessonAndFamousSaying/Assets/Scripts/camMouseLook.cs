using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour
{
    private const float THIRD_Y_AXIS_MIN = 0;
    private const float Y_AXIS_MIN = -50f;
    private const float Y_AXIS_MAX = 70f;
    
    Vector2 smoothV;

    private float mouseX, mouseY;

    public float sensitivity = 2f;
    public float smoothing = 2f;

    GameObject character;

	// Use this for initialization
	void Start ()
    {
        //Set target game object to it's parent
        character = this.transform.parent.gameObject;
        mouseX += 180f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update only if it is first person view
        if (this.GetComponent<Camera>().enabled)
        {
            //mouseDelta
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

            mouseX += smoothV.x;
            mouseY -= smoothV.y;

            mouseY = Mathf.Clamp(mouseY, Y_AXIS_MIN, Y_AXIS_MAX);

            transform.localRotation = Quaternion.AngleAxis(mouseY, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseX, character.transform.up);
        }
        else
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY -= Input.GetAxis("Mouse Y");
            mouseY = Mathf.Clamp(mouseY, THIRD_Y_AXIS_MIN, Y_AXIS_MAX);
        }
	}
}
