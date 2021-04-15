using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    PlayerInventory inventory;
    public Transform inventoryParent;
    // Start is called before the first frame update
    void Start()
    {
        inventory = PlayerInventory.playerInv;
        inventory.onItemChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("updating UI");
    }
}
