using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log ("1");

			this.transform.position = eventData.position;



	}

	public void OnDrag(PointerEventData eventData)
	{

			this.transform.position = eventData.position;

	}

	public void OnEndDrag(PointerEventData eventData)
	{
	this.transform.position = eventData.position;
	}

}

