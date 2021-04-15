using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create/Item")]
public class Items : ScriptableObject, IBuyable<int>, IDamageModifyable<int>, IUseable
{
    new public string Name = "Item";
    public Sprite sprite = null;
    public Character character;

    //TODO: Make codeable Items



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        //will get rid of stuff from playerInv
        //done in playerInventory
    }

    public void Buy(int buyPrice)
    {
        //make able to effect player money
    }

    //public void Sell(int sellPrice)
    //{
    //    //figure out if you need to sell or not, if not get rid of this
    //}

    public void DamageReduce(int damageReduce)
    {
        this.character.HP += damageReduce;
    }

    public void DamageEnhance(int damageEnhance)
    {
        this.character.diceSides.GenericResult += 1;
    }

    public void DamageChangeDice()
    {
        //will change player damage die (1d6>2d4>1d12>2d6) 1d6 range 1-6, avg 3, 2d4 range 2-8 avg 4,
    }
}
