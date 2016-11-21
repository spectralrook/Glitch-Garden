using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float healthPoints = 100f;
	
	public void DealDamage (float damage) {
		healthPoints -= damage;	
		
		if (healthPoints <= 0) {
			DestroyObject ();
		}
	}
	
	public void DestroyObject () {
		Destroy(gameObject);
	}
}
