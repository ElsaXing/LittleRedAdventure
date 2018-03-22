using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Add-Ons/PluggableAI/EnemyStats")]
public class EnemyStats : ScriptableObject {

	public float moveSpeed = 1f;
	public float lookRange = 1f;

	public float attackRange = 1f;
	public float attackRate = 1f;
	public int attackDamage = 1;


}
