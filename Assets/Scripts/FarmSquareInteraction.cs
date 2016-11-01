using UnityEngine;
using System.Collections;

public class FarmSquareInteraction : Interactable {
	private FarmSquare farmSquare;

	void Start(){
	
		farmSquare = gameObject.GetComponent<FarmSquare> ();
	
	}
	public override void Interact()
	{
		Player player = GameObject.Find ("Player").GetComponent<Player> ();

		//if(){} player.heldItem is plantable, plant it and remove 1 from player
		if (farmSquare.occupied == false) {
			farmSquare.occupied = true;
		}
	}
}
