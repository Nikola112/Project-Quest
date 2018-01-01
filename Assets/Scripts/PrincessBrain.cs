using System.Collections.Generic;
using UnityEngine;

public class PrincessBrain : MonoBehaviour {

	public Vector3 target;
	[SerializeField]
	private Transform player;
	[Header("signals princess to follow player")]
	public bool signal=false;

	private bool see;
	private bool followsPlayer;

	public bool runInFear=false;

	[SerializeField]
	public float Radius=20;// radius range for searching objects

	[SerializeField]
	private float loseInterest=2f;// loses interest faster if not looking
	private float currentLoseInterest=1f;
	[SerializeField]
	private float interestTimer=15;
	private float currentTimer;

	float angle;
	// Use this for initialization
	void Start () {
		
	}

	Vector3 findNewTarget(LayerMask mask,Vector3 targetPosition,float radius)//finds new target with a given tag
	{
		//targetPosition, radius, -transform.forward
		RaycastHit[] hits = Physics.SphereCastAll(targetPosition, radius, -transform.forward,Mathf.Infinity,mask);
		if (hits.Length == 0) {
			Debug.Log (GameManager.instance.GetNearestObject (transform.position, mask));
			return GameManager.instance.GetNearestObject (transform.position, mask);
		}
		int neki = Random.Range (0, hits.Length);
		return hits [neki].collider.transform.position;


	}

	// Update is called once per frame
	void Update () {
		
		angle = Vector3.Angle (player.forward, transform.position-player.position);
		if (angle > 60) {
			see = false;
		} else {
			see = true;
		}

		/*deo koda za targeta ka kom treba da ide */
		if (signal == true) {
			followsPlayer = true;
			currentTimer = interestTimer;
			signal = false;
		}
		if (see == true) {
			currentLoseInterest = 1f;
		} else {
			currentLoseInterest = loseInterest;
		}


		if (followsPlayer == true && currentTimer>0) {
			if (runInFear) {
				followsPlayer = false;
				/*finds new target to be object*/
				//	target =transform.position+((player.position - transform.position)*3);
				target = findNewTarget (LayerMask.NameToLayer ("StaticObjects"),transform.position+((player.position - transform.position)*3), Radius);
			}
			target = player.position;
			currentTimer-=Time.deltaTime * currentLoseInterest;
		}
		else if(followsPlayer == true && currentTimer<=0){
			followsPlayer=false;
			/*finds new target to be interactable VVV*/
			target = findNewTarget (LayerMask.NameToLayer ("Interactables"), transform.position, Radius);

		}
		if (followsPlayer == false && Vector3.Distance (target, transform.position) < 3) {
			//warns player
		}

	}
}

