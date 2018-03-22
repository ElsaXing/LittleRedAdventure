using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class StateController : MonoBehaviour {

	public State currentState;
	public EnemyStats enemyStats;
	public Transform eyes;
	public State remainState;

	//[HideInInspector] public Navigation navigation;
	[HideInInspector] public List<Transform> wayPointList;
	[HideInInspector] public int nextWayPoint;
	[HideInInspector] public Transform chaseTarget;

	private bool aiActive;

	void Awake () {
		//navigation = GetComponent<Navigation> ();
	} 

	public void SetupAI (bool aiActivionFormManager, List<Transform> wayPointFromManager) {
		wayPointList = wayPointFromManager;
		aiActive = aiActivionFormManager;
		//navigation.enabled = aiActive; 
	}

	void Update(){
		if (!aiActive)
			return;
		currentState.UpdateState (this);
	}

	void OnDrawGizmos () {
		if (currentState != null && eyes != null) {
			Gizmos.color = currentState.sceneGizmoColor;
			Gizmos.DrawWireSphere (eyes.position, enemyStats.lookRange);
		}
	}

	public void TransitionToState (State nextState) {
		if (nextState != remainState) {
			currentState = remainState;
		}
	}
}
