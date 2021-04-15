using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Items item;

    public Image icon;

    public void AddItem(Items items)
    {
        item = items;

        icon.sprite = item.sprite;
        icon.enabled = true;
    }

    public void ClearInvSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
