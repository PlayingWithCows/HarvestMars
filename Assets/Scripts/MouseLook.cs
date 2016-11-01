using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	public float mouseSensitivity;
	public float upDownRange = 60f;

	private CanvasManager canvasManager;
	private float vRot = 0;

	void Start(){
		canvasManager = GameObject.Find ("CanvasManager").GetComponent<CanvasManager> ();
	}
	// Update is called once per frame
	void Update () {

		if (!canvasManager.playerInventoryOpen) {
			float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
			transform.Rotate (0, rotLeftRight, 0);
	
			vRot -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
			vRot = Mathf.Clamp (vRot, -upDownRange, upDownRange);
			Camera.main.transform.localRotation = Quaternion.Euler (vRot, 0, 0);
		}
	}
}
