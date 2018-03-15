using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class Item : MonoBehaviour {

	public enum ItemType { KeyItem, DummyItem };
	[SerializeField] public ItemType itemType;
	[SerializeField] public int itemGroupIndex;

	public GameObject objectModel;

	private Vector3 myResetPos;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake () {
		myResetPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Enable () {
		gameObject.SetActive(true);
	}

	public void Disable () {
		gameObject.SetActive(false);
	}

	public void ResetPos() {
		// gameObject.transform.position = myResetPos;
	}
}
