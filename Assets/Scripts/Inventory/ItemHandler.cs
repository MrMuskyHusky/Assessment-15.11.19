using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public int itemId = 0;
	public ItemTypes itemType;
	public int amount = 1;
	
	public void OnCollection()
	{
        if(itemType == ItemTypes.Money) // Are we money
		{
            LinearInventory.money += amount;
		   
		}
		else if(itemType == ItemTypes.Craftable || itemType == ItemTypes.Food || itemType == ItemTypes.Potion || itemType == ItemTypes.Ingredient) // Are we stackable
		{
		    int found = 0;
			int addIndex = 0;
			for (int i = 0; i < LinearInventory.inv.Count; i++)
			{
			    if(itemId == LinearInventory.inv[i].ID)
				{
				    found = 1;
					addIndex = i;
					break;
				}
			}
			if(found == 1)
			{
			    LinearInventory.inv[addIndex].Amount += amount;
			}
			else
			{
			    LinearInventory.inv.Add(ItemData.CreateItem(itemId));
				if(amount > 1)
				{
				    for (int i = 0; i < LinearInventory.inv.Count; i++)
					{
					    if(itemId == LinearInventory.inv[i].ID)
						{
						    LinearInventory.inv[i].Amount = amount;
						}
					}
				}
			}
		}
		else // No? just add
		{
		    LinearInventory.inv.Add(ItemData.CreateItem(itemId));
		}
		Destroy(gameObject);
	}
}
