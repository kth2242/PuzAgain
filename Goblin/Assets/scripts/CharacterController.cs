using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed = 1f;
    private Animator anim;
    private CHARACTER_STATE charS;
	public GameObject[] enemy;
	private float enemyDetectRange = 6.5f;

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
		SetMovement();
		CheckNearEnemy();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            charS = CHARACTER_STATE.ATTACK;
		
        SetAnimator();

        //Turning off the lock mode of the cursor (makes cursor visible)
        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}

	void SetMovement()
	{
		float translation = Input.GetAxis("Vertical");
		float straffe = Input.GetAxis("Horizontal");

		anim.SetFloat ("translation", translation);
		anim.SetFloat ("straffe", straffe);

		translation *= Time.deltaTime * speed;
		straffe *= Time.deltaTime * speed;

		if (translation == 0 && straffe == 0)
			charS = CHARACTER_STATE.IDLE;
		else if (Input.GetKey (KeyCode.LeftShift))
		{
			charS = CHARACTER_STATE.RUN;
			translation *= 2f;
			straffe *= 2f;
		}
		else
			charS = CHARACTER_STATE.WALK;
		
		transform.Translate(straffe, 0, translation);
	}

	void CheckNearEnemy()
	{
		for(int i = 0; i < enemy.Length; ++i)
		{
			float distance = Vector3.Distance (enemy [i].transform.position, this.transform.position);

			if (distance < enemyDetectRange)
				charS = CHARACTER_STATE.STRAFE;
		}

		float translation = Input.GetAxis("Vertical");
		float straffe = Input.GetAxis("Horizontal");

		if (translation == 0 && straffe == 0)
			charS = CHARACTER_STATE.IDLE;
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
			anim.SetBool("STRAFE_ON", false);
        }
        else if (charS == CHARACTER_STATE.WALK)
        {
            anim.SetBool("IDLE_ON", false);
            anim.SetBool("WALK_ON", true);
            anim.SetBool("RUN_ON", false);
            anim.SetBool("ATTACK_ON", false);
            anim.SetBool("DEAD_ON", false);
			anim.SetBool("STRAFE_ON", false);
        }
        else if (charS == CHARACTER_STATE.RUN)
        {
            anim.SetBool("IDLE_ON", false);
            anim.SetBool("WALK_ON", false);
            anim.SetBool("RUN_ON", true);
            anim.SetBool("ATTACK_ON", false);
            anim.SetBool("DEAD_ON", false);
			anim.SetBool("STRAFE_ON", false);
        }
        else if (charS == CHARACTER_STATE.ATTACK)
        {
            anim.SetBool("IDLE_ON", false);
            anim.SetBool("WALK_ON", false);
            anim.SetBool("RUN_ON", false);
            anim.SetBool("ATTACK_ON", true);
            anim.SetBool("DEAD_ON", false);
			anim.SetBool("STRAFE_ON", false);
        }
        else if (charS == CHARACTER_STATE.DEAD)
        {
            anim.SetBool("IDLE_ON", false);
            anim.SetBool("WALK_ON", false);
            anim.SetBool("RUN_ON", false);
            anim.SetBool("ATTACK_ON", false);
            anim.SetBool("DEAD_ON", true);
			anim.SetBool("STRAFE_ON", false);
        }
		else if (charS == CHARACTER_STATE.STRAFE)
		{
			anim.SetBool("IDLE_ON", false);
			anim.SetBool("WALK_ON", false);
			anim.SetBool("RUN_ON", false);
			anim.SetBool("ATTACK_ON", false);
			anim.SetBool("DEAD_ON", false);
			anim.SetBool("STRAFE_ON", true);
		}
    }
}
