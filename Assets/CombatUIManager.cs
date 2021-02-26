using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public CameraManagement cameras;
    public SceneManage sceneManage;

    public GameObject combatCanvas;
    public GameObject boardCanvas;

    public Text playerHealthText;
    public Text enemyHealthText;

    public Entity player; 
    public int enemyHealth = 100;

    public int playerDamage;
    public int enemyDamage;

    public Text playerDamageText;
    public Text enemyDamageText;

    void Start()
    {
        playerHealthText.text = player.HP.ToString();
        enemyDamageText.text = enemyHealth.ToString();

        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void attack()
    {
        if (enemyHealth > 0)
        {
            playerDamage = UnityEngine.Random.Range(1, 6);
            playerDamageText.text = playerDamage.ToString();

            enemyHealth -= playerDamage;
            enemyHealthText.text = enemyHealth.ToString();

            enemyDamage = UnityEngine.Random.Range(1, 6);
            enemyDamageText.text = enemyDamage.ToString();

            player.HP -= enemyDamage;

            playerHealthText.text = player.HP.ToString();
        }

        if(enemyHealth <= 0)
        {
            cameras.changeCameras();
            sceneManage.ResumeGame();
            enemyHealth = 0;
            combatCanvas.SetActive(false);
            boardCanvas.SetActive(true);
           
        }
    }
}

