using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private Player player;
	private CanvasManager canvasManager;


	// Use this for initialization
	void Start () {
		canvasManager = GameObject.Find ("CanvasManager").GetComponent<CanvasManager> ();
		player = GameObject.Find ("Player").GetComponent<Player> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

//			Ray ray = GameObject.Find("HeadCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);    
//			Vector3 point = ray.origin + (ray.direction * 7f);    
//
//
//			float realMousePos = (point.x - transform.position.x)*0.7f;
//
//			gameManager.TapHappenedAtPosition (realMousePos);

		}

		if (Input.GetButton ("Use") && player.timeSinceLastUse >= player.useCooldown) {
			player.UseThing ();

		}
		if (Input.GetButtonDown ("Fire")) {
			
		}
		if (Input.GetKeyDown ("b")) {
			canvasManager.TogglePlayerInventory ();
		}


	}
}
