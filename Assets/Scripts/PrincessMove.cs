﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PrincessMove : MonoBehaviour {
	PrincessBrain br;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		br = GetComponent<PrincessBrain> ();
	}

	// Update is called once per frame
	void Update () {
		agent.SetDestination (br.target);
	}
}
