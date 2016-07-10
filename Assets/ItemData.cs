using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

	public Item item;
	public int amount = 1;
	public int slot;

	private Vector2 offset;
	private Inventory inv;
	private Text text;
	private Tooltip tooltip;

	void Awake(){
		text = GetComponentInChildren<Text> ();
		text.enabled = false;	

	}

	void Start(){
		
		text.text = amount.ToString();
		InvokeRepeating ("UpdateItemNumber", 0.1f, 5);
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		tooltip = inv.GetComponent<Tooltip> ();
	}

	public void UpdateItemNumber(){
		text.text = amount.ToString();
		if (amount <= 1) {
		
			text.enabled = false;
		
		} else{
		
			text.enabled = true;
		
		}
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log ("down");
		if (item != null) {
			offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log ("1");
		if (item != null) {
			offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
			this.transform.SetParent (this.transform.parent.parent);
			this.transform.position = eventData.position -offset;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log ("2");
		if (item != null) {
			this.transform.position = eventData.position - offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log ("3");
		if (item != null) {
			this.transform.SetParent (inv.slots[slot].transform);
			this.transform.position = inv.slots[slot].transform.position;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;

		}
	}



	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log ("enter");
		tooltip.Activate(item);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log ("exit");
		tooltip.Deactivate ();
	}
}
