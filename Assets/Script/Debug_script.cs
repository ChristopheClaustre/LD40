using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_script : MonoBehaviour {

    public bool startDiscution;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(startDiscution)
        {
            startDiscution = false;
            gameObject.GetComponent<VictimeGenerator>().generateVictime();
        }

    }
}
