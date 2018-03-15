using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class KeyCard : MonoBehaviour {

	[SerializeField] public int cardIndex;

	public GameObject cardModel;

	private bool bNeeded = true;

	private Vector3 resetPos;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake () {
		resetPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Enable () {
		GetComponent<VRTK_InteractableObject>().enabled = true;
		cardModel.GetComponent<Renderer>().material.color = new Color(0.745f, 0.651f, 0.541f, 1.0f);
	}

	public void Disable () {
		GetComponent<VRTK_InteractableObject>().enabled = false;
		cardModel.GetComponent<Renderer>().material.color = new Color(0.745f, 0.651f, 0.541f, 0.5f);
	}

	public void Detach () {
		GetComponent<VRTK_InteractableObject>().enabled = false;
	}

	public void MakeNoLongerNeeded() {
		bNeeded = false;
	}

	public bool IsNeeded () {
		return bNeeded;
	}

	public void ResetLocation() {
		// gameObject.transform.position = resetPos;
	}
}
