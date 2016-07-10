using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {
	
	public GameObject inventorySlot, inventoryItem;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();
	ItemDatabase database;

	int slotNumber = 32;
	private GameObject inventoryPanel, slotPanel;

	void Start()
	{
		database = GetComponent<ItemDatabase> ();
		inventoryPanel = GameObject.Find ("InventoryPanel");
		slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;

		for (int i = 0; i < slotNumber; i++) {
			items.Add (new Item ());
			slots.Add(Instantiate (inventorySlot));
			slots [i].GetComponent<InventorySlot> ().slotID = i;
				slots[i].transform.SetParent(slotPanel.transform);
			slots [i].name = "Inventory Slot " + i;
		}



		AddItem (3,1);
		AddItem (3,2);
		AddItem (4,4);
		AddItem (4,1);
		AddItem (4,1);
		AddItem (4, 1);
		AddItem (4, 20);
	}


	public void AddItem(int id, int amount)
	{

		if (amount < 1) {
			return;
		}

		Item itemToAdd = database.FetchItemByID (id);
		if (itemToAdd == null) {
			Debug.Log ("ID does not exist: " + id);
			return;
		}

		if (itemToAdd.Stackable && ItemIsInInventory (itemToAdd)) {
			for (int i = 0; i < items.Count; i++) {

				if (items [i].ID == id) {
					ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
					for (int x = 0; x < amount; x++) {
						
						data.amount++;
						data.UpdateItemNumber ();
					}

					break;
				
				}
			}

		} else {


			for (int i = 0; i < items.Count; i++) {
			
				if (items [i].ID == -1) {
			
					items [i] = itemToAdd;
					GameObject itemObj = Instantiate (inventoryItem);
					itemObj.GetComponent<ItemData> ().item = itemToAdd;
					itemObj.GetComponent<ItemData> ().slot = i;
					itemObj.transform.position = Vector2.zero;
					itemObj.name = itemToAdd.Slug;
					itemObj.transform.SetParent (slots [i].transform);

					itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;

					
					if (amount > 1) {
						AddItem (id, amount - 1);
					}

					break;
				}

		
			}
		}

	}

	bool ItemIsInInventory(Item item){
	
		for (int i = 0; i < items.Count; i++) {
		
			if (items [i].ID == item.ID) {
			
				return true;
			
			} 
		
		}
		return false;
	
	}




}
