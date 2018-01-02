using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHARACTER_STATE
{
	IDLE,
	WALK,
	RUN,
	DEAD,
	ATTACK
}

public class Patrol : MonoBehaviour {

	public GameObject[] destination;
	public float offset = 1f;
	private int i = 0;
	//private float speed = 5f;
	private CHARACTER_STATE charS;
	private Animator anim;

	void Start()
	{
		charS = CHARACTER_STATE.IDLE;
		anim = GetComponent<Animator> ();
		anim.SetBool ("IDLE_ON", true);
	}

	// Update is called once per frame
	void Update () {

		SetAnimator ();

		if (i < destination.Length)
		{
			charS = CHARACTER_STATE.WALK;
			this.transform.position = Vector3.MoveTowards(transform.position, destination [i].transform.position, /*speed **/ Time.deltaTime);

            Vector3 lookDirection = destination[i].transform.position - this.transform.position;
            Quaternion R = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 1.5f);

            if (IsObjectNearTarget(this.transform.position, destination[i].transform.position))
				++i;
        }
		else
			charS = CHARACTER_STATE.IDLE;
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
		if(charS == CHARACTER_STATE.IDLE)
		{
			anim.SetBool ("IDLE_ON", true);
			anim.SetBool ("WALK_ON", false);
			anim.SetBool ("RUN_ON", false);
			anim.SetBool ("ATTACK_ON", false);
			anim.SetBool ("DEAD_ON", false);
		}
		else if(charS == CHARACTER_STATE.WALK)
		{
			anim.SetBool ("IDLE_ON", false);
			anim.SetBool ("WALK_ON", true);
			anim.SetBool ("RUN_ON", false);
			anim.SetBool ("ATTACK_ON", false);
			anim.SetBool ("DEAD_ON", false);
		}
		else if(charS == CHARACTER_STATE.RUN)
		{
			anim.SetBool ("IDLE_ON", false);
			anim.SetBool ("WALK_ON", false);
			anim.SetBool ("RUN_ON", true);
			anim.SetBool ("ATTACK_ON", false);
			anim.SetBool ("DEAD_ON", false);
		}
		else if(charS == CHARACTER_STATE.ATTACK)
		{
			anim.SetBool ("IDLE_ON", false);
			anim.SetBool ("WALK_ON", false);
			anim.SetBool ("RUN_ON", false);
			anim.SetBool ("ATTACK_ON", true);
			anim.SetBool ("DEAD_ON", false);
		}
		else if(charS == CHARACTER_STATE.DEAD)
		{
			anim.SetBool ("IDLE_ON", false);
			anim.SetBool ("WALK_ON", false);
			anim.SetBool ("RUN_ON", false);
			anim.SetBool ("ATTACK_ON", false);
			anim.SetBool ("DEAD_ON", true);
		}
	}
}
