using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ActionBar : MonoBehaviour {

	private Inventory inventory;
	private int slotNumber = 8;
	public GameObject inventorySlot, inventoryItem;
	public List<GameObject> slots = new List<GameObject>();
	public List<GameObject> items = new List<GameObject>();

	void Start(){

		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();

		for (int i = 0; i < slotNumber; i++) {
			slots.Add(Instantiate (inventorySlot));
			slots [i].GetComponent<InventorySlot> ().slotID = i;
			slots[i].transform.SetParent(this.transform);
			slots [i].name = "ActionBar Slot " + i;

			items.Add(Instantiate (inventoryItem));
			items[i].GetComponent<ActionBarItemData> ().slot = i;
			items[i].transform.position = Vector2.zero;
			items[i].transform.SetParent (slots [i].transform);
		}
	}

}
