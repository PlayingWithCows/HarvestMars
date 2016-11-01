using UnityEngine;
using System.Collections;

public class FarmSquare : MonoBehaviour {

	public float decayTime = 100f;
	public bool occupied = false;
	public bool soilWatered = false;
	public float wateredTimer = 50f;
	public Material[] materials;


	private float timeWithoutCrop, timeWatered;
	private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
		meshRenderer = gameObject.transform.Find ("TilledMesh").GetComponent<MeshRenderer> ();

		Invoke ("wateredSoil", 10f);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.GetComponentInChildren<Crop> () != null && !occupied) {
		
			occupied = true;
		
		}
		if (!occupied) {
			timeWithoutCrop += Time.deltaTime;
		}
		if (timeWithoutCrop >= decayTime) {
		
			Decay ();
		
		}
		if (soilWatered) {
		
			timeWatered += Time.deltaTime;

			if (timeWatered >= wateredTimer) {
			
				drySoil ();

			}
		
		}
	}


	void Decay(){
	
		Destroy (gameObject);

	}

	public void wateredSoil(){
		soilWatered = true;
		meshRenderer.material = materials [1];
		timeWithoutCrop = 0;
	}
	public void drySoil(){
		soilWatered = false;
		meshRenderer.material = materials [0];
	}
}
