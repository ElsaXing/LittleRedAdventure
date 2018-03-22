using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager {

	public Transform[] spawnPoints;

	[HideInInspector] public GameObject instance;

	private StateController stateController;

	public void SetupAI(List<Transform> wayPointList) {
		stateController = instance.GetComponent<StateController> ();
		stateController.SetupAI (true, wayPointList);
	}
}
