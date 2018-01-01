using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessSignal : MonoBehaviour {
	PrincessBrain br;
	// Use this for initialization
	void Start () {
		br = GetComponent<PrincessBrain> ();
	}


	void OnCollisionEnter(Collision collision){
		if(collision.collider.CompareTag("Rock"))
			br.signal = true;


	}
}
