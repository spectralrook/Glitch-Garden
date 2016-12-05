using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	
	public Camera myCamera;
	
	private GameObject parent;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find("Defenders");
		
		if (!parent) {
			parent = new GameObject("Defenders");
		}		
		
		if (!myCamera) {
			myCamera = FindObjectOfType<Camera>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;		
		Quaternion zeroRot = Quaternion.identity;
		
		
		GameObject newDefender = Instantiate(defender, roundedPos, zeroRot) as GameObject;
		newDefender.transform.parent = parent.transform;	
		
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		
		return new Vector2 (newX, newY);
		
	}
	
	Vector2 CalculateWorldPointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3( mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		
		//Camera camera = FindObjectOfType<Camera>();
		//Vector3 p = camera.ScreenToWorldPoint(new Vector3( mousePosition.x, mousePosition.y, camera.nearClipPlane));
		//return new Vector2(p.x,p.y);
		
		return worldPos;
	}
}
