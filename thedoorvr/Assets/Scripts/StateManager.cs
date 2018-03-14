using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class StateManager : MonoBehaviour {

	// Static instance of GameManager which allows it to be accessed by any other script.
	public static StateManager instance = null;

	// Current state the game is in, also the num of cards completed
	private int mState;
	
	[SerializeField] private KeyCard[] mCards;
	[SerializeField] private Vector3[] mDoorLocations;
	[SerializeField] private Item[] mItems;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake() {
		// Check if instance already exists, and set to this if DNE
		if (instance == null) {
			instance = this;
		}
		
		// Destroy this if manager already exists
		else if (instance != this) {
			Destroy(gameObject);
		} 
		
		// Keeps integrity of game manager between scenes
		DontDestroyOnLoad(gameObject);
		
		//Call the InitGame function to initialize the first level 
		InitGame();
	}
	
	//Initializes the game for each level.
	void InitGame() {
		mState = 0;

		mCards[0].Enable();
		for (int i = 1; i < mCards.Length; ++i) {
			mCards[i].Disable();
		}

		foreach (Item item in mItems) {
			item.Disable();
		}
	}
	
	//Update is called every frame.
	void Update() {
		
	}

	public void ActivateRoom() {
		// Vector3 nextLocation = mDoorLocations[mState];

		foreach (Item item in mItems) {
			if (item.itemGroupIndex == mState) {
				item.Enable();
			}
		}

	}

	public void ActivateNextCard() {
		++mState;
		// reached last state in the game
		if (mState >= mCards.Length) {
			EndGame();
		}
		else {
			mCards[mState].Enable();
		}
	}

	void EndGame() {

	}

}
