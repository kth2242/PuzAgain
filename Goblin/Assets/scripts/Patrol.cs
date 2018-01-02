using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHARACTER_STATE
{
	IDLE,
	WALK,
	RUN,
	DEAD,
	ATTACK,
	STRAFE
}

public class Patrol : MonoBehaviour {
	
	public float offset = 1f;
	private CHARACTER_STATE charS;
	private Animator anim;
	public float wanderingRange = 3f;
	public GameObject character;
	private float enemyDetectRange = 6.5f; // should be same value in CharacterController.cs

	private Vector3 destination;

	void Start()
	{
		charS = CHARACTER_STATE.IDLE;
		anim = GetComponent<Animator> ();
		anim.SetBool ("IDLE_ON", true);
		destination = new Vector3(Random.Range(this.transform.position.x - wanderingRange, this.transform.position.x + wanderingRange),
			0, Random.Range(this.transform.position.z - wanderingRange, this.transform.position.z + wanderingRange));
	}

	// Update is called once per frame
	void Update () {

		SetAnimator ();

		/* if citizen goblin get to the place, then set the next place */
		if (IsObjectNearTarget (this.transform.position, destination))
			destination = new Vector3 (Random.Range (this.transform.position.x - wanderingRange, this.transform.position.x + wanderingRange),
				0, Random.Range (this.transform.position.z - wanderingRange, this.transform.position.z + wanderingRange));
		/* if citizen goblin find the main character (main character is close to the citizen goblin) */
		else if (Vector3.Distance (this.transform.position, character.transform.position) < enemyDetectRange)
		{
			/* citizen goblin start to look at the main character and do nothing */
			charS = CHARACTER_STATE.IDLE;
			Vector3 lookDirection = character.transform.position - this.transform.position;
			Quaternion R = Quaternion.LookRotation(lookDirection);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 10f);
		}
		/* patrol towards the destination position defined above */
		else
		{
			charS = CHARACTER_STATE.WALK;
			this.transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime);

			Vector3 lookDirection = destination - this.transform.position;
			Quaternion R = Quaternion.LookRotation(lookDirection);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 3f);
		}
	}

	bool IsObjectNearTarget(Vector3 _object, Vector3 _target)
	{
		float dx = _target.x - _object.x;
		float dy = _target.y - _object.y;
		float dz = _target.z - _object.z;

		if (dx <= offset && dx >= -offset
		    && dy <= offset && dy >= -offset
		    && dz <= offset && dz >= -offset)
			return true;
		else
			return false;
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
