using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class ActionBarItemData : MonoBehaviour{

	public Item item;
	public int slot;

	private ActionBar actionBar;
	private Inventory inv;
	private Text text;


	void Awake(){
		text = GetComponentInChildren<Text> ();
		text.enabled = false;	

	}

	void Start(){
		

		InvokeRepeating ("UpdateItemNumber", 0.1f, 1);
		InvokeRepeating ("UpdateSlotImages", 0.1f, 1);
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		actionBar = GameObject.Find ("ActionBar").GetComponent<ActionBar> ();
		if (inv.slots [slot].transform.GetChild (0).GetComponent<ItemData> ().amount.ToString () != null) {
			text.text = inv.slots [slot].transform.GetChild (0).GetComponent<ItemData> ().amount.ToString ();
		} else {
			text.text = "";
		
		}
	}

	public void UpdateSlotImages(){

		if (inv.items [slot].Slug != null) {
			gameObject.name = inv.items [slot].Slug;
		} else {
			gameObject.name = "noName";
		}


		GetComponent<Image> ().sprite = inv.items [slot].Sprite;


	}

	public void UpdateItemNumber(){
		text.text = inv.slots [slot].transform.GetChild (0).GetComponent<ItemData> ().amount.ToString();
		if (inv.slots [slot].transform.GetChild (0).GetComponent<ItemData> ().amount <= 1) {

			text.enabled = false;

		} else{

			text.enabled = true;

		}
	}


}
