using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Add-Ons/PluggableAI/Decisions/Look")]
public class LookDecision : Decision {

	public override bool Decide (StateController controller) {
		bool targetVisible = Look (controller);
		return targetVisible;
	}

	private bool Look(StateController controller) {

		Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange, Color.green);

		RaycastHit2D hit =  Physics2D.CircleCast (controller.eyes.position, controller.enemyStats.lookRange, controller.eyes.forward, controller.enemyStats.lookRange);

		if (hit.collider.CompareTag ("Player")) {
			return true;
		} else {
			return false;
		}


	//	if (Physics2D.CircleCast (controller.eyes.position, controller.enemyStats.lookRange, controller.eyes.forward, controller.enemyStats.lookRange)
	//	    && hit.collider.CompareTag ("Player")) {
	//		controller.chaseTarget = hit.transform;
	//		return true;
	//	} else {
	//		return false;
	//	}
	}
}
