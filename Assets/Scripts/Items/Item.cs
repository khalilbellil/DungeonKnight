using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public enum PassiveType
{
    Healer, SpeedBoost, CriticBoost
}

public class Item : MonoBehaviour
{
	public bool isPickup = false;

	public enum AllItems
	{
		coin, potion, arrow, passive
	}

	//Vars
	public AllItems itemType;
        

    // --- all initializes and updates --- //
    virtual public void Init()
	{
		//RandomItemSpawn(new Vector3());
		Debug.Log("initialize item");
	}

	virtual public void ItemUpdate()
	{

		Debug.Log("update item");
	}

	virtual public void ItemFixedUpdate()
	{
		Debug.Log("basic fixedupdate");
	}
	// -------------------------------- //

	public void AddItem()
	{

		Debug.Log("item added/loot added");
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		//if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		if(collision.gameObject == PlayerManager.Instance.player.gameObject)
		{
			CollidedWithPlayer(PlayerManager.Instance.player);
			Destroy(gameObject);
		}
	}

	protected virtual void CollidedWithPlayer(Player player)  //Ovverriden in children
	{

	}
	public static Item RandomItemSpawn(Vector3 location)
	{
		//GameObject gameObject = new GameObject();
		//gameObject.AddComponent<SpriteRenderer>();
		Item toReturn;
		List<AllItems> totalList = System.Enum.GetValues(typeof(AllItems)).Cast<AllItems>().ToList();
		AllItems randomValue = (AllItems)totalList[Random.Range(0, totalList.Count)];
		toReturn = LoadItem(randomValue, location);
		// it works to spawn a random item
		Debug.Log("this is the random item spawned: " + randomValue);

		return toReturn;
	}

	public static Item LoadItem(AllItems randomValue, Vector3 location)
	{
		GameObject newItem = null;
		switch (randomValue)
		{
			case AllItems.coin:
				newItem = (GameObject)Resources.Load("Prefabs/Items/Coin");
				break;
			case AllItems.potion:
				newItem = (GameObject)Resources.Load("Prefabs/Items/Potion");
				break;
			case AllItems.arrow:
				newItem = (GameObject)Resources.Load("Prefabs/Items/ArrowItem");
				break;
            case AllItems.passive:
                int r = Random.Range(0, 2);
                if (r == 0)
                {
                    newItem = (GameObject)Resources.Load("Prefabs/Items/HealerP");
                }
                else
                {
                    newItem = (GameObject)Resources.Load("Prefabs/Items/SpeedBoosterP");
                }
                
                break;
			default:
				Debug.LogError("Unhandled switch case: " + randomValue);				
				break;
		}
		GameObject go = Instantiate(newItem, location, Quaternion.identity);
		Item itemToReturn = go.GetComponent<Item>();
		itemToReturn.Init();
		return itemToReturn;

	}
}