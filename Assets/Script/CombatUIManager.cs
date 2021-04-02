using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CombatUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Variables
    public CameraManagement cameras;
    public SceneManage sceneManage;
    public BasicEnemyTEST monster;
    public GameObject enemyMonster;

    public GameObject combatCanvas;
    public GameObject boardCanvas;

    public Animator uICanAnim;

    public Animator playerAnim;

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

    public Slider playerHealthSlider;
    public Slider enemyHealthSlider;

    public GameObject boardUI;
    public GameObject playerAttack;
    public GameObject playerCharacter;

    public Text turnText;

    public static event System.Action<BasicEnemyTEST> monsterEvent;
    public static event System.Action<GameObject> monsterGameObject;
    public static event System.Action<GameObject> playerGO;
    #endregion




    void Start()
    {
        playerHealthText.text = player.HP.ToString();
        enemyDamageText.text = enemyHealth.ToString();
        enemyHealth = monster.HP;
        enemyHealthText.text = enemyHealth.ToString();
        playerHealthSlider.value = player.HP;
        enemyHealthSlider.value = enemyHealth;

    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthText.text = enemyHealth.ToString();
        if (player.HP <= 0)
        {
            this.gameObject.SetActive(false);
        }

        playerHealthSlider.value = player.HP;
        enemyHealthSlider.value = enemyHealth;
    }

    public void attack()
    {
        if (enemyHealth > 0)
        {
            playerDamage = UnityEngine.Random.Range(playerDamageMin, playerDamageMax);
            playerDamageText.text = playerDamage.ToString();
            playerHealthSlider.value = player.HP;

            enemyHealth -= playerDamage;
            enemyHealthText.text = enemyHealth.ToString();


            //uICanAnim.SetBool("enemyIsDamaged", true);
            monsterGameObject?.Invoke(enemyMonster);

            StartCoroutine(turn());

           
        }

        if (enemyHealth <= 0)
        {
            turnReset();
            playerAttack.SetActive(true);
            cameras.changeCameras();
            sceneManage.ResumeGame();
            enemyHealth = monster.HP;
            combatCanvas.SetActive(false);
            boardCanvas.SetActive(true);
            boardUI.SetActive(true);
            monsterEvent?.Invoke(monster);
            

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
        enemyHealthSlider.value = enemyHealth;
        enemyDamageText.text = enemyDamage.ToString();

        player.HP -= enemyDamage;

        uICanAnim.SetBool("playerIsDamaged", true);
        playerGO?.Invoke(playerCharacter);
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

    public void enemyDamageReset()
    {
        uICanAnim.SetBool("enemyIsDamaged", false);
    }

    public void turnReset()
    {
        uICanAnim.SetBool("turnIsStarting", false);
        uICanAnim.SetBool("playerIsDamaged", false);
    }


}

