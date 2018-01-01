using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private List<GameObject> dynamicObjects = new List<GameObject> ();

	private void Awake()
	{
		if (instance == null)
		{
			instance = gameObject.GetComponent<GameManager> ();
			DontDestroyOnLoad (gameObject);
		}
	}

	public void AddObject(GameObject toAdd)
	{
		dynamicObjects.Add (toAdd);
	}

	public Vector3 GetNearestObject(Vector3 position, LayerMask mask)
	{
		List<GameObject> objectPositions = dynamicObjects.FindAll (x => ((1 << x.layer) & mask.value) != 0);
		Vector3 nearestPos = Vector3.zero;
		float nearstDist = float.MaxValue;

		for (int i = 0; i < objectPositions.Count; i++)
		{
			float dist = Vector3.Distance (objectPositions [i].transform.position, position);
			if (dist < nearstDist)
			{
				nearstDist = dist;
				nearestPos = objectPositions [i].transform.position;
			}
		}

		return nearestPos;
	}
}
