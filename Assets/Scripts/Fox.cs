using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {
	
	private Animator animator;
	private Attacker attacker;
	
	
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();	
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		GameObject obj = other.gameObject;
		
		if (!obj.GetComponent<Defender>()) {
			return;
		}
		
		if (obj.GetComponent<Stone>()) {
			this.animator.SetTrigger("jumpTrigger");
		} else if (obj.GetComponent<Gnome>()) {
			this.animator.SetBool("isAttacking", true);
			attacker.Attack (obj);
		} else if (obj.GetComponent<Cactus>()) {
			this.animator.SetBool("isAttacking", true);
			attacker.Attack (obj);
		} else if (obj.GetComponent<StarTrophy>()) {
			this.animator.SetBool("isAttacking", true);
			attacker.Attack (obj);
		}
	}	
}
