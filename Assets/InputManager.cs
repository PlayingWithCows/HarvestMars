using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	private GameManager gameManager;
	private Player player;
	private CanvasManager canvasManager;

	private MouseLook horizMouseLook, vertMouseLook;
	// Use this for initialization
	void Start () {
		canvasManager = GameObject.Find ("CanvasManager").GetComponent<CanvasManager> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		player = GameObject.Find ("Player").GetComponent<Player> ();
		horizMouseLook = GameObject.Find("Player").GetComponent<MouseLook> ();
		vertMouseLook = GameObject.Find("HeadCamera").GetComponent<MouseLook> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (!gameManager.gameStarted) {
				gameManager.gameStarted = true;
			}


			Ray ray = GameObject.Find("HeadCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);    
			Vector3 point = ray.origin + (ray.direction * 7f);    


			float realMousePos = (point.x - transform.position.x)*0.7f;

//			gameManager.TapHappenedAtPosition (realMousePos);

		}

		if (Input.GetButton ("Use") && player.timeSinceLastUse >= player.useCooldown) {
			player.UseThing ();

		}
		if (Input.GetButtonDown ("Fire")) {
			player.FireWeapon ();

		}
		if (Input.GetKeyDown ("b")) {
			canvasManager.TogglePlayerInventory ();
			if (canvasManager.playerInventoryOpen) {
				horizMouseLook.invOpen = true;
				vertMouseLook.invOpen = true;
			} else {
			
				horizMouseLook.invOpen = false;
				vertMouseLook.invOpen = false;
			
			}
		}
	}
}
