using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] attackers;
	
	//private GameObject parent;
	
	// Use this for initialization
	void Start () {
		//parent = GameObject.Find("Attackers");
		
		//if (!parent) {
		//	parent = new GameObject("Attackers");
		//}
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackers) {
			if (isTimeToSpawn(attacker)) {
				Spawn(attacker);
			}
		}
	}
	
	void Spawn (GameObject attacker) {
		GameObject newAttacker = Instantiate(attacker, this.transform.position, Quaternion.identity) as GameObject;
		newAttacker.transform.parent = this.transform;			
	}
	
	
	bool isTimeToSpawn (GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		
		float meanSpawnDelay = attacker.sceenEverySeconds;
		
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
		
		//return true;
	}
	
}


