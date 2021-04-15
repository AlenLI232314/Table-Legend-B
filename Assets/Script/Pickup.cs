using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Items item;
    void PickupItem()
    {
        Debug.Log("Picked up " + item.Name);
        PlayerInventory.playerInv.Add(item);

    }
}
