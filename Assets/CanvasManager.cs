using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	public bool standardCanvasOpen, playerInventoryOpen, dayEndCanvasOpen;


	private Canvas standardCanvas, playerInventoryCanvas, dayEndCanvas;


	void Start(){


		standardCanvas =  GameObject.Find ("StandardCanvas").GetComponent<Canvas> ();
		playerInventoryCanvas =  GameObject.Find ("InventoryCanvas").GetComponent<Canvas> ();
		dayEndCanvas = GameObject.Find ("DayEndCanvas").GetComponent<Canvas> ();
		standardCanvasOpen = true;
		playerInventoryOpen = false;
		dayEndCanvasOpen = false;	
		standardCanvas.enabled = true;
		playerInventoryCanvas.enabled = false;
		dayEndCanvas.enabled = false;
	
	}

	public void TogglePlayerInventory(){

		if (!playerInventoryOpen) {
			standardCanvas.enabled = false;
			playerInventoryCanvas.enabled = true;
			dayEndCanvas.enabled = false;

			standardCanvasOpen = false;
			playerInventoryOpen = true;
			dayEndCanvasOpen = false;
		
		} else {


				standardCanvas.enabled = true;
				playerInventoryCanvas.enabled = false;
				dayEndCanvas.enabled = false;

				standardCanvasOpen = true;
				playerInventoryOpen = false;
				dayEndCanvasOpen = false;
	

		
		}

	}
		
}
