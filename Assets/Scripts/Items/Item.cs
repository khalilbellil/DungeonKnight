using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	// --- all initializes and updates --- //
	virtual public void Init()
	{

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

	/*public static Item RandomItemSpawn(Vector2 loc)
	{
		GameObject go = new GameObject();
		go.AddComponent<SpriteRenderer>();
		Item toReturn;
		switch ()
		{
			item = go.AddComponent<Coin>();
		}
		return item;
	}*/
	
}
