using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//print (PlayerPrefsManager.GetMasterVolume() );
		//PlayerPrefsManager.SetMasterVolume(0.3f);
		//print (PlayerPrefsManager.GetMasterVolume() );
		
		//print (PlayerPrefsManager.IsLevelUnlocked(4));
		//PlayerPrefsManager.UnlockLevel(4);
		//print (PlayerPrefsManager.IsLevelUnlocked(4));
		
		print ("Difficulty: " + PlayerPrefsManager.GetDifficulty() );
		//PlayerPrefsManager.SetDifficulty(0.3f);
		//print (PlayerPrefsManager.GetDifficulty() );
	}
	
}
