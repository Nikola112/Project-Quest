using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Rock : MonoBehaviour
{
	private SphereCollider col;
	private float radius = 2f;

	private void Awake()
	{
		col = GetComponent<SphereCollider> ();

		col.isTrigger = true;
		col.radius = radius;
	}

	public void Interact(GameObject other)
	{
		if (other.CompareTag ("Player"))
		{
			PlayerInventory inventory = other.GetComponent<PlayerInventory> ();

			if (inventory.AddRock ())
			{
				Destroy (gameObject);
			}
		}
	}
}
