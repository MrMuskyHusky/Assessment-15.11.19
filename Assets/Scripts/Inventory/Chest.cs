using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public bool showChest;
    public GameObject inventoryDisplay;
    public int[] itemsToSpawn;
    public RawImage[] items;
    public List<Item> chestInv = new List<Item>();
    public Item selectedChestItem;
    public Button[] takeItem;
    public Texture2D empty;
    private void Start()
    {
        inventoryDisplay.SetActive(false);

        // itemsToSpawn = new int[Random.Range(1, 8)];
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            chestInv.Add(ItemData.CreateItem(itemsToSpawn[Random.Range(0, 3)]));
            Debug.Log(chestInv[i].Name);
            Debug.Log(chestInv[i].IconName);
        }
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<RawImage>().texture = empty;
            if (i < chestInv.Count)
            {
                items[i].GetComponent<RawImage>().texture = chestInv[i].IconName;
            }
        }
    }

    public void ChestInteract()
    {
        showChest = !showChest;
        inventoryDisplay.SetActive(showChest);
        if (showChest == true)
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
            selectedChestItem = null;
        }

    }
    public void OpenChest()
    {

        showChest = !showChest;
        inventoryDisplay.SetActive(showChest);
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<RawImage>().texture = empty;
            if (i < chestInv.Count)
            {
                items[i].GetComponent<RawImage>().texture = chestInv[i].IconName;
            }
        }
    }

    public void TakeItem(int element)
    {
        chestInv.Remove(chestInv[element]);
        LinearInventory.inv.Add(ItemData.CreateItem(chestInv[element].ID));
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<RawImage>().texture = empty;
            if (i < chestInv.Count)
            {
                items[i].GetComponent<RawImage>().texture = chestInv[i].IconName;
            }
        }
    }

    //public void DropItem(int i)
    //{
    //    if (chestInv[i] != null)
    //    {
    //        Instantiate(chestInv[i].MeshName);
    //        chestInv.Remove(chestInv[i]);
    //    }
    //}
}
