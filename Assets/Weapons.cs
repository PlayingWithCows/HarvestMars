using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {
	public int currentWeapon;

	public Transform[] weapons;
	// Use this for initialization
	void Start () {
		changeWeapon(0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			changeWeapon(0);
		}
	}

	public void changeWeapon(int num) {
		currentWeapon = num;
		for(int i = 0; i < weapons.Length; i++) {
			if(i == num)
				weapons[i].gameObject.SetActive(true);
			else
				weapons[i].gameObject.SetActive(false);
		}
	}
		
}
