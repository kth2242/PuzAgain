using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed = 1f;
    private Animator anim;
    private CHARACTER_STATE charS;

    // Use this for initialization
    void Start ()
    {
        //Hide the curser and lock the cursor inside the game
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        if ((translation + straffe) == 0)
            charS = CHARACTER_STATE.IDLE;
        else
            charS = CHARACTER_STATE.WALK;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            charS = CHARACTER_STATE.ATTACK;

        transform.Translate(straffe, 0, translation);
        SetAnimator();

        //Turning off the lock mode of the cursor (makes cursor visible)
        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}

    void SetAnimator()
    {
        if (charS == CHARACTER_STATE.IDLE)
        {
            anim.SetBool("IDLE_ON", true);
            anim.SetBool("WALK_ON", false);
            anim.SetBool("RUN_ON", false);
            anim.SetBool("ATTACK_ON", false);
            anim.SetBool("DEAD_ON", false);
        }
        else if (charS == CHARACTER_STATE.WALK)
        {
            anim.SetBool("IDLE_ON", false);
            anim.SetBool("WALK_ON", true);
            anim.SetBool("RUN_ON", false);
            anim.SetBool("ATTACK_ON", false);
            anim.SetBool("DEAD_ON", false);
        }
        else if (charS == CHARACTER_STATE.RUN)
        {
            anim.SetBool("IDLE_ON", false);
            anim.SetBool("WALK_ON", false);
            anim.SetBool("RUN_ON", true);
            anim.SetBool("ATTACK_ON", false);
            anim.SetBool("DEAD_ON", false);
        }
        else if (charS == CHARACTER_STATE.ATTACK)
        {
            anim.SetBool("IDLE_ON", false);
            anim.SetBool("WALK_ON", false);
            anim.SetBool("RUN_ON", false);
            anim.SetBool("ATTACK_ON", true);
            anim.SetBool("DEAD_ON", false);
        }
        else if (charS == CHARACTER_STATE.DEAD)
        {
            anim.SetBool("IDLE_ON", false);
            anim.SetBool("WALK_ON", false);
            anim.SetBool("RUN_ON", false);
            anim.SetBool("ATTACK_ON", false);
            anim.SetBool("DEAD_ON", true);
        }
    }
}
