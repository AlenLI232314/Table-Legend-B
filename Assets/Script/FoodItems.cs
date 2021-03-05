using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItems : MonoBehaviour, IBuyable<int>, IUseable
{
    public Character character;

    public int foodHeal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy(int buyPrice)
    {
        //character.AddToInventory(food item here)
    }

    public void Sell(int sellPrice)
    {
        //character.RemoveFromInventory(food item here)
    }

    public void Use()
    {
        this.character.HealDamage(foodHeal);
    }
}
