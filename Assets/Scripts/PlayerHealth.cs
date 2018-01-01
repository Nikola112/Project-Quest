using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField]
	private int health = 1;

	public void DamagePlayer(int damage)
	{
		health -= damage;

		if (damage <= 0)
		{
			Death ();
		}
	}

	private void Death()
	{
		// TODO: Implement Death
	}
}
