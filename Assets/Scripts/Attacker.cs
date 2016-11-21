using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Health))]
public class Attacker : MonoBehaviour {
	
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator>();
		//Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		//myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		
		if (!currentTarget) {
			animator.SetBool("isAttacking",false);
		}
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log(this.name + " trigger enter with " + other.name);
	}
	
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health targetHealth = currentTarget.GetComponent<Health>();
			
			if (targetHealth) {
				targetHealth.DealDamage(damage);
				Debug.Log(this.name + " caused damage: " + damage + " to " + currentTarget.name);
			}
		} else {
			animator.SetBool("isAttacking",false);
		}
	}	
	
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}

