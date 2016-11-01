using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public bool canBeUsed;
	public GameObject[] targets;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UseByPlayer(){
		if (canBeUsed) {
			foreach (GameObject target in targets) {
		
				target.SendMessage ("Use");
		
			}
		}
	}
}
