using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TurnManager turnManager;
    
    public GameObject combatCanvas;
    public GameObject boardCanvas;

    public Text playerHealthText;
    public Text enemyHealthText;

    //public int playerHealth = turnManager.character.HP;
    //public int enemyHealth = turnManager.basicenemyTEST.HP;

    public int playerDamage;
    public int enemyDamage;
    public int playerHealth;
    public int enemyHealth;

    public Text playerDamageText;
    public Text enemyDamageText;

    void Start()
    {
        playerHealth = this.turnManager.character.HP;
        enemyHealth = this.turnManager.basicEnemyTEST.HP;
        playerDamage = this.turnManager.character.diceSides.GenericResult;
        playerHealthText.text = playerHealth.ToString();
        enemyDamageText.text = enemyHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = this.turnManager.character.HP;
        enemyHealth = this.turnManager.basicEnemyTEST.HP;
    }

    public void attack()
    {
        turnManager.EndTurn();
        playerDamageText.text = playerDamage.ToString();
        Debug.Log(playerDamage);
        //if (enemyHealth >= 0)
        //{
        //    playerDamage = UnityEngine.Random.Range(1, 6);
        //    playerDamageText.text = playerDamage.ToString();

        //    enemyHealth -= playerDamage;
        //    enemyHealthText.text = enemyHealth.ToString();

        //    enemyDamage = UnityEngine.Random.Range(1, 6);
        //    enemyDamageText.text = enemyDamage.ToString();

        //    playerHealth -= enemyDamage;

        //    playerHealthText.text = playerHealth.ToString();
        //}
    }
}

