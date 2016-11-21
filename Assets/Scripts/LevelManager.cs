using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public float autoLoadNextLevelAfter;
	
	private int loadedLevel;
	
	void Start () {
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level auto load disabled, use a positive number in seconds");
		} else {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	
	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
	
	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
	
	
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		loadedLevel = scene.buildIndex;
	}
	
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		//Application.Quit ();
		SceneManager.UnloadScene(loadedLevel);
	}
	
	public void LoadNextLevel() {
		SceneManager.LoadScene(loadedLevel + 1); 
	}

}
