using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

public class ItemDatabase : MonoBehaviour {
	private List<Item> itemList = new List<Item>();


	//private TextAsset readText;
	public JsonData itemData;
	public string read;
	void Start()
	{
		read = File.ReadAllText (Application.dataPath+"/ItemsJson.json");
		itemData = JsonMapper.ToObject(read);
//		Debug.Log (itemData[0]["title"] + " ; " + itemData [0] ["id"]);
		ConstructItemList ();
//		Debug.Log (itemList);


		//itemData = JsonUtility.FromJson (readText.text);




	}

	void ConstructItemList(){

		for (int i = 0; i < itemData.Count; i++) 
		{
//			Debug.Log (itemData [i] ["itemtype"].ToString ());
			if (itemData [i] ["itemtype"].ToString() == "tool") {
				itemList.Add (new Item ((int)itemData[i]["id"], itemData[i]["title"].ToString(),  itemData [i] ["itemtype"].ToString(),
					(bool)itemData[i]["stackable"], (bool)itemData[i]["sellable"], float.Parse(itemData[i]["workspeed"].ToString()), 
					(int)itemData[i]["energycost"], (int)itemData [i] ["value"], 
					(int)itemData [i] ["damage"], (int)itemData [i] ["rarity"], itemData [i] ["slug"].ToString ()
				));
			} else if (itemData [i] ["itemtype"].ToString() == "seed") {
				
				itemList.Add (new Item ((int)itemData [i] ["id"], itemData [i] ["title"].ToString (),  itemData [i] ["itemtype"].ToString(), 
					(bool)itemData [i] ["stackable"], (bool)itemData [i] ["sellable"],(int)itemData [i] ["growtime"],
					(bool)itemData [i] ["multiharvest"],(int)itemData [i] ["multiharvestdelay"], (int)itemData [i] ["value"], 
					(int)itemData [i] ["season"], (int)itemData [i] ["rarity"], itemData [i] ["slug"].ToString ()	

				));
			} else if (itemData [i] ["itemtype"].ToString() == "food") {
				itemList.Add (new Item ((int)itemData [i] ["id"], itemData [i] ["title"].ToString (), itemData [i] ["itemtype"].ToString(), 
					(bool)itemData [i] ["stackable"], (bool)itemData [i] ["sellable"], (int)itemData [i] ["value"],
					(int)itemData [i] ["healthrecovery"], (int)itemData [i] ["energyrecovery"], (int)itemData [i] ["rarity"], 
					itemData [i] ["slug"].ToString ()	

				));
			} else {
				Debug.Log ("ItemsJson Object " + itemData [i] ["id"] + " does not contain a valid itemtype!");
			}



		}

	}


	public Item FetchItemByID(int id)
	{
		for (int i = 0; i < itemList.Count; i++) 
		{
			if (itemList [i].ID == id) 
			{
				return itemList [i];
			}


		}
		return null;
	}

	public Item FetchItemBySlug(string slug)
	{
		for (int i = 0; i < itemList.Count; i++) 
		{
			if (itemList [i].Slug == slug) 
			{
				return itemList [i];
			}
		
		}
		return null;
	}




}
	

public class Item
{

	public int ID { get; set; }
	public string Title { get; set; }
	public string Itemtype { get; set; }
	public bool Stackable { get; set; }
	public bool Sellable { get; set; }
	public float Workspeed { get; set; }
	public int Energycost { get; set; }
	public int Value { get; set; }
	public int Damage { get; set; }
	public int Rarity { get; set; }
	public string Slug { get; set; }
	public int Growtime { get; set; }
	public bool Multiharvest { get; set; }
	public int Multiharvestdelay { get; set; }
	public int Season { get; set; }
	public int Healthrecovery { get; set;}
	public int Energyrecovery { get; set;}
	public Sprite Sprite { get; set; }


	public Item(int id, string title, string itemtype, bool stackable, bool sellable, float workSpeed, int energyCost, int value, int damage, int rarity, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Itemtype = itemtype;
		this.Stackable = stackable;
		this.Sellable = sellable;
		this.Workspeed = workSpeed;
		this.Energycost = energyCost;
		this.Value = value;
		this.Damage = damage;
		this.Rarity = rarity;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("Sprites/Items/" + slug);
	}
		

	public Item(int id, string title, string itemtype, bool stackable, bool sellable, int growtime, bool multiharvest, int multiharvestdelay, int value, int season, int rarity, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Itemtype = itemtype;
		this.Stackable = stackable;
		this.Sellable = sellable;
		this.Growtime = growtime;
		this.Multiharvest = multiharvest;
		this.Multiharvestdelay = multiharvestdelay;
		this.Value = value;
		this.Season = season;
		this.Rarity = rarity;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("Sprites/Items/" + slug);
	}

	public Item(int id, string title, string itemtype, bool stackable, bool sellable, int value, int healthrecovery, int energyrecovery, int rarity, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Itemtype = itemtype;
		this.Stackable = stackable;
		this.Sellable = sellable;
		this.Value = value;
		this.Healthrecovery = healthrecovery;
		this.Energyrecovery = energyrecovery;
		this.Rarity = rarity;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("Sprites/Items/" + slug);
	}
	public Item()
	{
		this.ID = -1;
		this.Sprite = Resources.Load<Sprite> ("Sprites/Items/nothing");
	}

}