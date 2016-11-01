using UnityEngine;
using System.Collections;
using System.CodeDom.Compiler;

public class Door : MonoBehaviour {
	public float openingSpeed;
	public bool startsOpen = false;
	public bool canBeTriggered;
	public bool canBeTriggeredByPlayer;
	public bool autoCloses;
	public float autoCloseAfter;
	public AudioClip moveSound, shutSound, blockedSound;
	public float x, y, z; // decides in which direction the door moves.


	private float timeOpen = 0f;
	private Vector3 openPos, closedPos;
	private float openingPercentage;
	private bool isOpening, isClosing;
	private bool isOpen;
	// Use this for initialization
	void Start () {
		openPos = new Vector3 (transform.position.x + x, transform.position.y + y, transform.position.z + z);
		closedPos = transform.position;

		if (startsOpen) {
			openingPercentage = 1;
		} else {
			openingPercentage = 0;
		}



		if (startsOpen) {
			transform.position = openPos;
		}
	}
	
	// Update is called once per frame
	void Update () {

		MoveDoor ();
	}

	public bool Trigger(){

		if (canBeTriggered) {
			
		
			if (isOpen && !isClosing) {
			
				CloseDoor ();
				Debug.Log ("closing");
				return true;

			} else if (!isOpen && !isOpening) {
			
				OpenDoor ();
				Debug.Log ("opening");
				return true;
			} 
		
		}
		return false;

	}


	void CloseDoor(){
		if (!isClosing) {
			isClosing = true;
			openingPercentage = 1;
		}
	}

	void OpenDoor(){
		if (!isOpening) {
			Debug.Log ("OpenDoor()");
			isOpening = true;
			openingPercentage = 0;
		}
	}

	void MoveDoor(){
		if (isOpening) {
			
			openingPercentage += openingSpeed*Time.deltaTime;
		Debug.Log (transform.position.x);
			transform.position = Vector3.Lerp (closedPos, openPos, openingPercentage);

			if(openingPercentage >=0.99){
				transform.position = openPos;
				Debug.Log ("fully Open");
				isOpening=false;
				isOpen=true;
				openingPercentage = 1;
			}

		}



		if (isClosing) {
			openingPercentage -= openingSpeed*Time.deltaTime;
			Debug.Log (transform.position.x);
			transform.position = Vector3.Lerp (closedPos, openPos, openingPercentage);
	
			if(openingPercentage <=0.01){
				transform.position = closedPos;
				Debug.Log ("fully closed");
				isClosing=false;
				isOpen=false;
				openingPercentage = 0;
			}
		}


		if (autoCloses && isOpen) {
			timeOpen += Time.deltaTime;

			if (timeOpen >= autoCloseAfter) {
				timeOpen = 0;
				Trigger ();
			
			}

		
		}
	
	}
		

	void OnTriggerEnter(Collider col) {
	
		if (col.CompareTag("Player") && canBeTriggeredByPlayer) {
			
			if (!isOpening || !isClosing) {
				Debug.Log ("Player Touched");
				Trigger ();
			}
		}
	
	}
	public void UseByPlayer(){

		if (canBeTriggeredByPlayer) {
			if (!Trigger ()) {
				Debug.Log ("Trigger did not work!");
			}
		}

	}

	public void Use(){
	

		if(!Trigger ()){
			Debug.Log("Trigger did not work!");
		}

	}
}
