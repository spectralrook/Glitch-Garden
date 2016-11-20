using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {
	
	private MusicManager musicManager;
	
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if (musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.SetVolume (volume);
		} else {
			Debug.LogWarning("Unable to find music manager in Start scene. Cannot set volume.");
		}
	}
	
}
