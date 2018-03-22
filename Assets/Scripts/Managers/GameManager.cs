using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	public List<Transform> wayPointForAI;
	public EnemyManager[] enemys;

	// Use this for initialization
	void Start () {
		SpawnAllEnemys ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SpawnAllEnemys() {
		for (int i = 0; i < enemys.Length; i++) {
			for (int r = 0; r < enemys [i].spawnPoints.Length; r++) {
				enemys [i].instance = Instantiate (enemyPrefabs [0], enemys [i].spawnPoints [r].position, new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
				enemys [i].SetupAI (wayPointForAI);
			}
		}
	}
}
