using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Add-Ons/PluggableAI/Decisions/Chase")]
public class ChaseDecision : Decision {
	public override bool Decide (StateController controller) {
		bool targetChaseable = Chase (controller);
		return targetChaseable;
	}

	private bool Chase(StateController controller) {
		return false;
	}
}
