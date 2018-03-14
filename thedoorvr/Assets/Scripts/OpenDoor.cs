using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public Vector3 doorEnd;
	public GameObject handleController;
	public GameObject doorRotator;

	private Vector2 vectorA;
	private Vector2 vectorB;

	private Quaternion doorAngle;

	// Use this for initialization
	void Start () {
		vectorA = new Vector2 (doorRotator.transform.position.x, doorRotator.transform.position.y) - new Vector2 (doorEnd.x, doorEnd.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (handleController != null) {
			// vector to moving handle
			vectorB = new Vector2 (doorRotator.transform.position.x, doorRotator.transform.position.y) - new Vector2 (handleController.transform.position.x, handleController.transform.position.y);

			float newAngle = (Vector2.Angle (vectorA, vectorB)) * 1.3f;

			if (newAngle - 100.0f < 20.0f) {
				// play door close sound
				newAngle = 100.0f;
			} else if (newAngle - 100.0f > 70.0f) {
				newAngle = 190.0f;
			}


			doorRotator.transform.localRotation = Quaternion.Euler (0.0f, newAngle - 100.0f, 0.0f);
		}

	}
}
