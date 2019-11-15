using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleInventory : MonoBehaviour
{

    public bool toggleInventory = true;

    private Canvas canv;

    void Start()
    {
        canv = GetComponent<Canvas>();
        if (canv.enabled == true)
        {
            canv.enabled = false;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory") && toggleInventory == true)
        {
            canv.enabled = !canv.enabled;
        }
    }

}
