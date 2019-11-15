using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool showShop;
    public int[] itemsToSpawn;
    public List<Item> shopInv = new List<Item>();
    public Item selectedShopItem;

    private void Start()
    {
        itemsToSpawn = new int[Random.Range(1, 11)];
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            itemsToSpawn[i] = Random.Range(0,4);
            shopInv.Add(ItemData.CreateItem(itemsToSpawn[i]));
        }
    }
    private void OnGUI()
    {
        if(showShop)
        {
            Vector2 scr = new Vector2(Screen.width/16, Screen.height/9);
            GUI.Box(new Rect(6.5f * scr.x, 0.25f * scr.y, 3f * scr.x, 0.3f * scr.y), "$"+LinearInventory.money);
            for (int i = 0; i < shopInv.Count; i++)
            {
                if (GUI.Button(new Rect(12.75f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), shopInv[i].Name))
                {
                    selectedShopItem = shopInv[i];
                }
            }
            if(selectedShopItem == null)
            {
                return;
            }
            else
            {
                GUI.Box(new Rect(13.5f * scr.x, 6.7f * scr.y, 3 * scr.x, 0.5f * scr.y), "$" + (selectedShopItem.Value + (int)selectedShopItem.Value/4));
                if(LinearInventory.money >= selectedShopItem.Value)
                {
                    if (GUI.Button(new Rect(13.5f * scr.x, 7.2f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Take"))
                    {
                        LinearInventory.inv.Add(ItemData.CreateItem(selectedShopItem.ID));
                        shopInv.Remove(selectedShopItem);
                        LinearInventory.money -= (selectedShopItem.Value + (int) selectedShopItem.Value / 4);
                        selectedShopItem = null;
                    }
                }
            }
        }
    }
}


