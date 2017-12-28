using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    [SerializeField] private int totalCubeCount = 0; 

	// Use this for initialization
	void Start () {        
        /* count the number of cubes */
        GameObject[] Cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject GO in Cubes)
            ++totalCubeCount;
    }
	
	// Update is called once per frame
	void Update () {       
    }

    void OnTriggerEnter(Collider col)
    {
        //if(col.CompareTag("Cube"))
        if (col.GetComponent<Collider>().tag == "Cube")
        {
            Destroy(col.gameObject);
            --totalCubeCount;
        }
    }
}
