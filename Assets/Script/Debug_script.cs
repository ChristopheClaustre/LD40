using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_script : MonoBehaviour {

    public bool reponsePlayer;
    public bool send;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(send)
        {
            send = false;
            gameObject.GetComponent<ONEPartieIManager>().playerAnswer(reponsePlayer);
        }
    }
}
