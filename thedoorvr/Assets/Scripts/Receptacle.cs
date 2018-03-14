using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptacle : MonoBehaviour {

	private enum ReceptacleType { CardReader, CoffeeMachine };
	[SerializeField] private ReceptacleType myReceptacleType;

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
		if (myReceptacleType == ReceptacleType.CardReader && other.gameObject.tag == "KeyCard") {
			// Destroy(other.gameObject);

			KeyCard keyCard = other.gameObject.GetComponent<KeyCard>();

			StateManager.instance.ActivateRoom();
			int keyCardNumber = keyCard.cardIndex;
			Debug.Log("<color=green>Collision:</color> Received Key Card " + keyCardNumber);
		}
		else if(myReceptacleType == ReceptacleType.CoffeeMachine && other.gameObject.tag == "Item")
        {
			Item receivedItem = other.gameObject.GetComponent<Item>();
			if (receivedItem.itemType == Item.ItemType.DummyItem) {
				// reset the current state
				Destroy(other.gameObject);
			}
			else if (receivedItem.itemType == Item.ItemType.KeyItem) {
				// move onto the next state
				Destroy(other.gameObject);
				StateManager.instance.ActivateNextCard();
			}
        }
	}
}