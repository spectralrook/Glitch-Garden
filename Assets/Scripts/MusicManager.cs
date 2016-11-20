using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Do Not Destroy on Load: " + name);
	}
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded(int level) {
		AudioClip audioClip = levelMusicChangeArray[level];
		Debug.Log("Playing clip: " + audioClip);
		
		if (audioClip) {
			audioSource.Stop ();
			audioSource.clip = audioClip;
			audioSource.loop = true;
			audioSource.Play();
		}
	}	
	
	public void SetVolume (float volume) {
		if (volume >= 0 && volume <= 1) {
			audioSource.volume = volume;
		} else {
			Debug.LogError("Volume value out of range");
		}
	}
}
