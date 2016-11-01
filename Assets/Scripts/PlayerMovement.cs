using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private CharacterController myController;
	//private Transform headCamera;

	public float moveSpeed;
	public float gravity;
	public float jumpSpeed;

	float verticalVelocity=0;

	private CanvasManager canvasManager;
	void Start(){

		myController = gameObject.GetComponent<CharacterController> ();
		canvasManager = GameObject.Find ("CanvasManager").GetComponent<CanvasManager> ();
		//headCamera = GameObject.Find("HeadCamera").transform;
	}


	// Update is called once per frame
	void Update () {
		

		if (!canvasManager.playerInventoryOpen) {
			float forwardSpeed = Input.GetAxis ("Horizontal") * moveSpeed;
			float sideSpeed = Input.GetAxis ("Vertical") * moveSpeed;
			if (!myController.isGrounded) {
				verticalVelocity += -gravity * Time.deltaTime;
			}
			Vector3 speed = new Vector3 (forwardSpeed, verticalVelocity, sideSpeed);

			speed = transform.rotation * speed;

			myController.Move (speed * Time.deltaTime);
		}
	}

	public void Jump(){
	
		if (myController.isGrounded)
		verticalVelocity = jumpSpeed;
	
	}
}
