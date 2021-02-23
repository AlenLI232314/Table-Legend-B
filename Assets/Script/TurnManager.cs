using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Character character;
    public BasicEnemyTEST basicEnemyTEST;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndTurn()
    {
        character.DealDamage(0,basicEnemyTEST,Dice.Six);
        CheckIfDead();
        if (!basicEnemyTEST.isAlive)
        {
            Debug.Log("EnemyDead");
        }
        else { EnemyTurn(); }
    }

    public void EnemyTurn()
    {
        basicEnemyTEST.DealDamage(0, character, Dice.Four);
        CheckIfDead();
        if (!character.isAlive)
        {
            Debug.Log("Character dead");
        }
        else { }
    }
    
    public void CheckIfDead()
    {
        if (character.HP <= 0)
        {
            character.Kill();
        }
        if (basicEnemyTEST.HP <= 0)
        {
            basicEnemyTEST.Kill();
        }
    }
}
