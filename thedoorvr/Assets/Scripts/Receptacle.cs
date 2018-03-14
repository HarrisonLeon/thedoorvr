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
			other.gameObject.GetComponent<KeyCard>().Detach();
			other.gameObject.GetComponent<KeyCard>().MakeNoLongerNeeded();
			
			// transform to put in slot properly
			other.transform.parent = transform;
			other.transform.localPosition = new Vector3(0.0521f, 0.1512f, 0f);
			other.transform.localRotation = Quaternion.Euler(0f, 0f, 97.16f);
			other.transform.localScale = new Vector3(0.104f, 0.006f, 0.0887f);

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
				other.transform.parent = transform;
				Destroy (other.gameObject);
			}
			else if (receivedItem.itemType == Item.ItemType.KeyItem) {
				// move onto the next state
				other.transform.parent = transform;
				Destroy (other.gameObject);
				StateManager.instance.ActivateNextCard();
			}
        }
	}
}

