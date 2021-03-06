﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysicsObject : MonoBehaviour {
	public float minGroundNormalY = .65f;
	public float gravityModifier = 1f;
	public float characterVelocity = 7;
	public float jumpTakeOffSpeed = 7;
	public float moveRange = 3;

	protected bool grounded;
	protected Vector2 groundNormal;
	protected Rigidbody2D rb2d;
	protected Vector2 velocity;
	protected ContactFilter2D contactFilter;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

	protected const float minMoveDistance = 0.001f;
	protected const float shellRadius = 0.01f;

	private float lastDirectionChangeTime;
	private readonly float directionChangeTime = 2f;
	private float movementDirection;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private Vector3 spawnPoint;


	void OnEnable () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

	}

	void Start () {
		contactFilter.useTriggers = false;
		contactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (gameObject.layer));
		contactFilter.useLayerMask = true;

		spawnPoint = rb2d.position;

		lastDirectionChangeTime = 0f;
		ChangeDirection ();
	}


	// Update is called once per frame
	void Update () {
		ChangeDirection ();
	}

	protected virtual void ChangeDirection () {
		float distance = Vector3.Distance (rb2d.position, spawnPoint);

		if (Time.time - lastDirectionChangeTime < directionChangeTime && Mathf.Abs (velocity.y) < 4.5 && distance < moveRange) {
			return;
		}

		lastDirectionChangeTime = Time.time;

		if (Mathf.Abs(velocity.y) < 4.5 && distance < moveRange) {
			movementDirection = Random.Range (-1f, 1f);
			if (movementDirection > 0f) {
				movementDirection = 1f;
			} else if (movementDirection < -0f) {
				movementDirection = -1f;
			}
		} else {
			movementDirection = - movementDirection;
			velocity.y = velocity.y / 2;
		}
			
		if (movementDirection < 0.01f) {
			spriteRenderer.flipX = true;	
		} else if (movementDirection > -0.01f) {
			spriteRenderer.flipX = false;
		}
	}


	void FixedUpdate() {
		velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
		velocity.x = characterVelocity * movementDirection;


		grounded = false;


		animator.SetFloat ("slimeVelocityY", velocity.y);
		Vector2 move = velocity * Time.deltaTime;

		Movement (move, false);

		if (grounded) {
			velocity.y = jumpTakeOffSpeed;
			move = velocity * Time.deltaTime;

			Movement (move, true);
		} 

	}
		

	void Movement (Vector2 move, bool yMovement) {
		float distance = move.magnitude;

		if (distance > minMoveDistance) {
			int count = rb2d.Cast (move, contactFilter, hitBuffer, distance + shellRadius);
			hitBufferList.Clear ();
			for (int i = 0; i < count; i++) {
				hitBufferList.Add (hitBuffer [i]);
			}

			for (int i = 0; i < hitBufferList.Count; i++) {
				Vector2 currentNormal = hitBufferList [i].normal;

				if (currentNormal.y > minGroundNormalY) {

					grounded = true;

					if (yMovement) {
						groundNormal = currentNormal;
						currentNormal.x = 0;
					}
				}

				float projection = Vector2.Dot (velocity, currentNormal);
				if (projection < 0) {
					velocity = velocity - projection * currentNormal;
				}

				float modifiedDistance = hitBufferList [i].distance - shellRadius;
				distance = modifiedDistance < distance ? modifiedDistance : distance;
			}
		}

		rb2d.position = rb2d.position + move.normalized * distance;
	}


}
