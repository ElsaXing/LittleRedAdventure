using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Add-Ons/PluggableAI/Actions/Patrol")]
public class PartolAction : AIAction {

	public override void Act (StateController controller) {
		Partol (controller);
	}

	private void Partol (StateController controller) {
	//	controller.navMeshAgent.destination = controller.wayPointList [controller.nextWayPoint].position;
	//	controller.navMeshAgent.Resume ();

	//	if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) {
	//		controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
	//	}

		Debug.Log ("Partol");
	}
}
