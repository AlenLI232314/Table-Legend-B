using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable<int>, IKillable
{
    public int HP { get; set; }
    public bool isAlive;
    public DifferentDiceSides diceSides;
    //TODO: Make OnKill close CombatUI
    //TODO: Check for any HealDamage, make function to heal damage.
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DealDamage(int DamageDealt, Entity entity, Dice die)
    {
        diceSides.RollingDice(die);
        DamageDealt = diceSides.GenericResult;
        entity.TakeDamage(DamageDealt);
    }

    public void Kill()
    {
        this.isAlive = false;
    }

    public void OnKill()
    {
        //does nothing yet
    }

    public void HealDamage(int DamageHealed)
    {
        this.HP += DamageHealed;
    }

    public void TakeDamage(int DamageTaken)
    {
        this.HP -= DamageTaken;
    }

    public void OnDamage()
    {
        //does nothing yet
    }
}
