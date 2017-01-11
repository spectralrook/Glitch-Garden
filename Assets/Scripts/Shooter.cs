using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {
	
	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	
	private Animator animator;
	
	private Spawner mainSpawner;
	
	private GameObject myLaneSpawner;
	
	
	void Start () {
		animator = GameObject.FindObjectOfType<Animator>();
		
		mainSpawner = GameObject.FindObjectOfType<Spawner>();
		
		projectileParent = GameObject.Find("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}
	
	void Update () {

		if (IsAttackerAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}
	
	// Look through all spawner's and set myLaneSpawner if found
	void SetMyLaneSpawner () {
		foreach (GameObject spawner in mainSpawner.spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				Debug.Log(spawner.transform.position.y + "," + transform.position.y);					
				myLaneSpawner = spawner;
				return;			
			}
		}

		Debug.LogError("Error: Unable to locate spawner in lane for " + this.name);
	}
	
	bool IsAttackerAheadInLane() {
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				Debug.Log(attacker.name);
				return true;
			}
		}
		
		// Attacker in lane, but behind us.
		return false;
	}
	
	private void FireGun () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

}
