using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxInv = 6;

    public static PlayerInventory playerInv; //part of singleton
    public List<Items> items = new List<Items>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    void Awake()
    {
        if (playerInv != null)
        {
            Debug.LogWarning("MORE THAN ONE INSTANCE OF PlayerInventory");
            return;
        }
        playerInv = this; //singleton
    }

    public void Add(Items item)
    {
        if (items.Count >= maxInv)
        {
            Debug.Log("No room in inventory");
            return;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Remove(Items item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
