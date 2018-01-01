using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour 
{
	public Transform cam;
	public Transform rockStart;
	public GameObject rock;
	public GameObject text;

	private PlayerInventory inventory;

	private void Awake()
	{
		inventory = GetComponent<PlayerInventory> ();
	}

	private void Update()
	{
		if (Input.GetButtonDown ("Throw"))
		{
			ThrowRock (rockStart.position, rockStart.forward * 10f);
		}
	}

	private void ThrowRock(Vector3 position, Vector3 direction)
	{
		if (inventory.ThrowRock ())
		{
			GameObject rock = Instantiate (this.rock, position, Quaternion.identity);
			Rigidbody rockRb = rock.GetComponent<Rigidbody> ();
			rockRb.AddForce (direction, ForceMode.Impulse);
			Destroy (rock, 5f);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag ("Interactable")) 
		{
			if (Vector3.Angle (cam.forward, other.transform.position - cam.position) < 20f)
			{
				if (!text.activeSelf)
					text.SetActive (true);

				if (Input.GetButtonDown ("Interact"))
				{
					Rock rock = other.GetComponent<Rock> ();
					rock.Interact (gameObject);
					text.SetActive (false);
				}
			} 
			else if (text.activeSelf)
			{
				text.SetActive (false);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}
