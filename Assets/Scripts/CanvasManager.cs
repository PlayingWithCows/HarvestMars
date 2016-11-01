using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	public bool standardCanvasOpen, playerInventoryOpen, dayEndCanvasOpen;


	private Canvas standardCanvas, dayEndCanvas;


	void Start(){


		standardCanvas =  GameObject.Find ("StandardCanvas").GetComponent<Canvas> ();

		dayEndCanvas = GameObject.Find ("DayEndCanvas").GetComponent<Canvas> ();
		standardCanvasOpen = true;
		playerInventoryOpen = false;
		dayEndCanvasOpen = false;	
		standardCanvas.enabled = true;
		dayEndCanvas.enabled = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update(){
		if (Input.GetKeyDown ("b")) {
			TogglePlayerInventory ();
		}
	}

	public void TogglePlayerInventory(){

		if (!playerInventoryOpen) {
			standardCanvas.enabled = false;
			dayEndCanvas.enabled = false;

			standardCanvasOpen = false;
			playerInventoryOpen = true;
			dayEndCanvasOpen = false;
			Cursor.lockState = CursorLockMode.None;
		
		} else {


				standardCanvas.enabled = true;
				dayEndCanvas.enabled = false;

				standardCanvasOpen = true;
				playerInventoryOpen = false;
				dayEndCanvasOpen = false;
				Cursor.lockState = CursorLockMode.Locked;

		
		}

	}
		
}
