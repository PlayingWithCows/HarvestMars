using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {
	
	public Item heldItem;

	void Start () {

	}
	

	void Update () {


	}



//	public void FireWeapon (){
//	
//		Ray ray = transform.GetComponentInChildren<Camera> ().ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2,0));
//		RaycastHit hit;
//
//		//animation and effects
//
//		if (Physics.Raycast (ray, out hit, 100)) {
//
//			if (hit.transform.GetComponent<Terrain>() && hit.distance <=2){
//				hit.transform.GetComponent<CreateFarmland> ().UpdatePosition (hit.point);
//
//				if (carriedItemType == 1) {
//					if (hit.transform.GetComponent<CreateFarmland> ().terrain.terrainData.splatPrototypes [hit.transform.GetComponent<CreateFarmland> ().surfaceIndex].texture.name == "farmland") {
//
//						Quaternion hitRotation = Quaternion.FromToRotation (Vector3.forward, hit.normal);
//
//						float newX = RoundToHalf (hit.point.x);
//						float newY = hit.point.y;
//						float newZ = RoundToHalf (hit.point.z);
//
//						Vector3 point = new Vector3 (newX, newY, newZ);
//						hit.transform.GetComponent<CreateFarmland> ().MakeTilledLand (point, hitRotation);
//
//					}
//				}
//
//			}
//
//			if (hit.transform.GetComponent<Enemy> ()) {
//				if (hit.distance <= weapons.weapons [weapons.currentWeapon].GetComponent<WeaponStats> ().range) {
//				
//					hit.transform.GetComponent<Enemy> ().TakeDamage (weapons.weapons [weapons.currentWeapon].GetComponent<WeaponStats> ().damage);
//				}
//			}
//		}
//	}

	private float RoundToHalf (float num){

		float variable =  Mathf.Round(num);

		return variable;

	}

}
