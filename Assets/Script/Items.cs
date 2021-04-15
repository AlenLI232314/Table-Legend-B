using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour, IBuyable<int>, IDamageModifyable<int>, IUseable
{
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
        //armor reduces dmg (-1 dmg w/ basic armor etc)
    }

    public void DamageEnhance(int damageEnhance)
    {
        //not sure if I should keep this (+1 to dmg w/ sword enchant or etc)
    }

    public void DamageChangeDice()
    {
        //will change player damage die (1d6>2d4>1d12>2d6) 1d6 range 1-6, avg 3, 2d4 range 2-8 avg 4,
    }
}
