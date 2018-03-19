using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerPhysicsObject {
	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	public GameObject[] Background1;
	public GameObject[] Background2;
	public float backgroundSpeed1;
	public float backgroundSpeed2;

	private SpriteRenderer spriteRenderer;
	private Animator animator;

	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
	}

	protected override void ComputeVelocity () {
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump") && grounded) {
			velocity.y = jumpTakeOffSpeed;
		} else if (Input.GetButtonUp ("Jump")) {
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}

		if (move.x > 0.01f) {
			if (spriteRenderer.flipX == true) {
				spriteRenderer.flipX = false;
			}
		} else if (move.x < -0.01f) {
			if (spriteRenderer.flipX == false) {
				spriteRenderer.flipX = true;
			}
		}

		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
		animator.SetFloat ("velocityY", velocity.y);

		targetVelocity = move * maxSpeed;


		//Background Move Speed
		foreach (GameObject background in Background1) {
			Vector3 deltaMove = Vector3.zero;
			deltaMove.x = Camera.main.velocity.x * Time.deltaTime * backgroundSpeed1;
			background.transform.position = background.transform.position + deltaMove;
		}

		foreach (GameObject background in Background2) {
			Vector3 deltaMove = Vector3.zero;
			deltaMove.x = Camera.main.velocity.x * Time.deltaTime * backgroundSpeed2;
			background.transform.position = background.transform.position + deltaMove;
		}
	}




}
