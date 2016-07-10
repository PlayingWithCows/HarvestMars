using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	private GameManager gameManager;
	private Player player;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (!gameManager.gameStarted) {
				gameManager.gameStarted = true;
			}


			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
			Vector3 point = ray.origin + (ray.direction * 7f);    


			float realMousePos = (point.x - transform.position.x)*0.7f;

			gameManager.TapHappenedAtPosition (realMousePos);

		}

		if (Input.GetButton ("Use") && player.timeSinceLastUse >= player.useCooldown) {
			player.UseThing ();

		}
		if (Input.GetButtonDown ("Fire")) {
			player.FireWeapon ();

		}
	}
}
