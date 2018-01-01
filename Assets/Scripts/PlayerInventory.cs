using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	[SerializeField]
	private int rocks = 0;

	public bool AddRock()
	{
		if (rocks >= 1)
		{
			return false;
		}

		rocks++;
		return true;
	}

	public bool ThrowRock()
	{
		if (rocks > 0)
		{
			rocks--;
			return true;
		}

		return false;
	}
}
