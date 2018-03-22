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
	public float attackTime = 0.5f;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private float lastAttackTime;


	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();

		lastAttackTime = 0f;
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
			spriteRenderer.flipX = false;
		} else if (move.x < -0.01f) {
			spriteRenderer.flipX = true;
		}

		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
		animator.SetFloat ("velocityY", velocity.y);

		targetVelocity = move * maxSpeed;


		//Background Move Speed
		foreach (GameObject background in Background1) {
			Vector3 deltaMove = Vector3.zero;
			deltaMove.x = Camera.main.velocity.x * Time.deltaTime * backgroundSpeed1;
			background.transform.position +=  deltaMove;
		}

		foreach (GameObject background in Background2) {
			Vector3 deltaMove = Vector3.zero;
			deltaMove.x = Camera.main.velocity.x * Time.deltaTime * backgroundSpeed2;
			background.transform.position = background.transform.position + deltaMove;
		}
	}


	protected override void Action () {
		if (Input.GetAxis ("Fire1") == 1 && Time.time - lastAttackTime > attackTime) {
			animator.SetTrigger ("playerAttack");
			lastAttackTime = Time.time;
			GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject enemy in enemys) {
				
			}
		}
	}

}
