using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public CameraManagement cameras;
    public SceneManage sceneManage;
    public BasicEnemyTEST monster;

    public GameObject combatCanvas;
    public GameObject boardCanvas;

    public Animator uICanAnim;

    public Text playerHealthText;
    public Text enemyHealthText;

    public Entity player;
    public int enemyHealth;

    public int playerDamage;
    public int enemyDamage;

    public int playerDamageMin;
    public int playerDamageMax;

    public int enemyDamageMin;
    public int enemyDamageMax;

    public Text playerDamageText;
    public Text enemyDamageText;

    public GameObject boardUI;
    public GameObject playerAttack;

    public Text turnText;


    void Start()
    {
        playerHealthText.text = player.HP.ToString();
        enemyDamageText.text = enemyHealth.ToString();
        enemyHealth = monster.HP;
        enemyHealthText.text = enemyHealth.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthText.text = enemyHealth.ToString();
        if (player.HP <= 0)
        {
            this.gameObject.SetActive(false);
        } 
    }

    public void attack()
    {
        if (enemyHealth > 0)
        {
            playerDamage = UnityEngine.Random.Range(playerDamageMin, playerDamageMax);
            playerDamageText.text = playerDamage.ToString();

            enemyHealth -= playerDamage;
            enemyHealthText.text = enemyHealth.ToString();

            uICanAnim.SetBool("enemyIsDamaged", true);

            StartCoroutine(turn());

           
        }

        if (enemyHealth <= 0)
        {

            cameras.changeCameras();
            sceneManage.ResumeGame();
            enemyHealth = monster.HP;
            combatCanvas.SetActive(false);
            boardCanvas.SetActive(true);
            boardUI.SetActive(true);


        }
    }

    public IEnumerator turn()
    {
        playerAttack.SetActive(false);
        Debug.Log("Begin Waiting");
        uICanAnim.SetBool("turnIsStarting", true);
        turnText.text = "Enemy Turn!";
        yield return new WaitForSecondsRealtime(5f);
        enemyDamage = UnityEngine.Random.Range(enemyDamageMin, enemyDamageMax);
        enemyDamageText.text = enemyDamage.ToString();

        player.HP -= enemyDamage;

        uICanAnim.SetBool("playerIsDamaged", true);

       

        playerHealthText.text = player.HP.ToString();
        Debug.Log("Stop Waiting");

        turnReset();

        yield return new WaitForSecondsRealtime(1f);

        turnText.text = "Player's Turn!";
        uICanAnim.SetBool("turnIsStarting", true);

        yield return new WaitForSecondsRealtime(2f);
        turnReset();
        playerAttack.SetActive(true);

    }

    public void damageReset()
    {
        uICanAnim.SetBool("playerIsDamaged", false);
    }

    public void enemyDamageReset()
    {
        uICanAnim.SetBool("enemyIsDamaged", false);
    }

    public void turnReset()
    {
        uICanAnim.SetBool("turnIsStarting", false);
    }


}

