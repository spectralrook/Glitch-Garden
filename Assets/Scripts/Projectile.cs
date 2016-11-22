using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float speed, damage;
	
	private GameObject currentTarget;	
	
	void Start () {
	
	}
	
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		GameObject obj = other.gameObject;
		
		Attacker attacker = other.gameObject.GetComponent<Attacker>();
		
		//if (!obj.GetComponent<Attacker>()) {
		//	return;
		//}
		
		Health targetHealth = obj.GetComponent<Health>();
			
		if (attacker && targetHealth) {
			targetHealth.DealDamage(damage);
			//Debug.Log(this.name + " projectile caused damage: " + damage + " to " + obj.name);
			Destroy (gameObject);	
		}
	}		
	
	// The following will not work because there is not a SpriteRenderer on the parent object
	// It is on the "body", under the parent object.
	//void OnBecameInvisible () {
	//	Destroy (gameObject);
	//}
}
