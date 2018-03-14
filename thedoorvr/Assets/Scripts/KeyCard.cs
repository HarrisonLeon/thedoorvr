using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class KeyCard : MonoBehaviour {

	[SerializeField] public int cardIndex;

	public GameObject cardModel;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake () {
		// cardModel = gameObject.transform.Find("Card").gameObject;
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
}
