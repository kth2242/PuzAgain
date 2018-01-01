using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDestination : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent thisAgent = null;
	public Transform destination = null;

	// Use this for initialization
	void Awake () {
		thisAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		//thisAgent.enabled = false;
		thisAgent.SetDestination (destination.position);
		//thisAgent.enabled = true;
	}
}
