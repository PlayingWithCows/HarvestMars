using UnityEngine;
using System.Collections;

public class WorldInteraction : MonoBehaviour {
	
	void Update()
	{
		if (Input.GetButtonDown ("AltFire")&& !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) 
		{
			GetInteraction ();
		}


	}

	void GetInteraction()
	{
		Ray interactionRay = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2,0));
		RaycastHit interactionInfo;
		if (Physics.Raycast (interactionRay, out interactionInfo, 10f )) {
			GameObject interactedObject = interactionInfo.collider.gameObject;
			if (interactedObject.tag == "Interactable Object") 
			{
				interactedObject.GetComponent<Interactable> ().Interact();
			} 

			if (interactedObject.tag == "Terrain") 
			{
				if (interactionInfo.transform.GetComponent<Terrain>() && interactionInfo.distance <=3){
					interactionInfo.transform.GetComponent<CreateFarmland> ().UpdatePosition (interactionInfo.point);
					
									
					if (interactionInfo.transform.GetComponent<CreateFarmland> ().terrain.terrainData.splatPrototypes [interactionInfo.transform.GetComponent<CreateFarmland> ().surfaceIndex].texture.name == "farmland") {
					
						Quaternion hitRotation = Quaternion.FromToRotation (Vector3.forward, interactionInfo.normal);
					
						float newX = RoundToHalf (interactionInfo.point.x);
						float newY = interactionInfo.point.y;
						float newZ = RoundToHalf (interactionInfo.point.z);
					
											Vector3 point = new Vector3 (newX, newY, newZ);
						interactionInfo.transform.GetComponent<CreateFarmland> ().MakeTilledLand (point, hitRotation);
					
										}
									
					
								}
			} 
			else 
			{
			}
		}
	}

	private float RoundToHalf (float num){

		float variable =  Mathf.Round(num);

		return variable;

	}
}
