using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private CharacterController myController;
	private Transform headCamera;

	public float moveSpeed;
	public float gravity;

	void Start(){

		myController = gameObject.GetComponent<CharacterController> ();
		headCamera = GameObject.Find("HeadCamera").transform;
	}


	// Update is called once per frame
	void Update () {

		Vector3 myVector = new Vector3 (0, 0, 0);

		myVector.x = Input.GetAxis ("Horizontal");
		myVector.z = Input.GetAxis ("Vertical");

		myVector = myVector * moveSpeed * Time.deltaTime;
		myVector = headCamera.rotation * myVector;

		float vVelocity = myController.velocity.y;
		myVector.y = vVelocity * Time.deltaTime;

		myController.Move (myVector);

		Vector3 myGravity = new Vector3 (0, -gravity*Time.deltaTime, 0);
		myController.Move (myGravity);
	}
}
