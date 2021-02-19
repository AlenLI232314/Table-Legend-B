using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable<int>, IKillable
{
    public int HP { get; set; }
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void DealDamage(int DamageDealt, Entity entity, Dice die)
    {
        entity.HP -= DamageDealt;
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
