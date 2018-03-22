using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {
	public SpriteRenderer spriteRenderer;
	public GameObject eye;

	protected bool spriteOriginallyFlipped;
	protected bool canDamage = true;

	private Vector3 eyeOffect = new Vector3 (0.5f, 0, 0);

	void Awake () {
		if (spriteRenderer != null) {
			spriteOriginallyFlipped = spriteRenderer.flipX;
		}
	}

	void FixedUpdate () {
		if (!canDamage)
			return;

		if (spriteRenderer != null && spriteRenderer.flipX != spriteOriginallyFlipped) {
			eyeOffect.x = -eyeOffect.x;
			eye.transform.position = transform.position + eyeOffect;
			spriteOriginallyFlipped = spriteRenderer.flipX;
		}
	}

	public void EnableDamage () {
		canDamage = true;
	}

	public void DisableDamage () {
		canDamage = false;
	}
}
