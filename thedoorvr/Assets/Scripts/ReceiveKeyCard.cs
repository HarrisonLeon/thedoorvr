﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveKeyCard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "KeyCard")
        {
            Destroy(other.gameObject);

			KeyCard keyCard = other.gameObject.GetComponent<KeyCard>();
			int keyCardNumber = keyCard.cardIndex;
			Debug.Log("<color=green>Collision:</color> Received Key Card " + keyCardNumber);
        }
	}
}