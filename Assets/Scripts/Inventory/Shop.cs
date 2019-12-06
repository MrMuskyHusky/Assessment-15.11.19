using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public bool showShop;
    public GameObject shopDisplay;
    public int[] itemsToSpawn;
    public RawImage[] items;
    public List<Item> shopInv = new List<Item>();
    public Item selectedShopItem;
    public Button[] buyItem;
    public Texture2D empty;

    private void Start()
    {
        //itemsToSpawn = new int[Random.Range(1, 8)];
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            shopInv.Add(ItemData.CreateItem(itemsToSpawn[Random.Range(0, 3)]));
            Debug.Log(shopInv[i].Name);
            Debug.Log(shopInv[i].IconName);
        }
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<RawImage>().texture = empty;
            if (i < shopInv.Count)
            {
                items[i].GetComponent<RawImage>().texture = shopInv[i].IconName;
            }
        }
    }
    public void ShopInteraction()
    {
        showShop = !showShop;
        shopDisplay.SetActive(showShop);
        if (showShop == true)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            selectedShopItem = null;
        }
    }

    public void OpenShop()
    {

        showShop = !showShop;
        shopDisplay.SetActive(showShop);
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<RawImage>().texture = empty;
            if (i < shopInv.Count)
            {
                items[i].GetComponent<RawImage>().texture = shopInv[i].IconName;
            }
        }
    }
    public void BuyItem(int element)
    {
        shopInv.Remove(shopInv[element]);
        LinearInventory.inv.Add(ItemData.CreateItem(shopInv[element].ID));
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<RawImage>().texture = empty;
            if (i < shopInv.Count)
            {
                items[i].GetComponent<RawImage>().texture = shopInv[i].IconName;
            }
        }
    }
}