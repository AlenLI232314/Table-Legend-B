using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class CombatUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Variables
    //Cameras for camera management.
    public CameraManagement cameras;
    //SceneManagement Script
    public SceneManage sceneManage;
    //Monster Data
    public BasicEnemyTEST monster;
    //Game object that stores components for Monster
    public GameObject enemyMonster;
    //Combat Canvas 
    public GameObject combatCanvas;
    //Board Canvas
    public GameObject boardCanvas;
    //UICanvasAnimator
    public Animator uICanAnim;
    //Animator for Player Game Object
    public Animator playerAnim;
    //Text for player and enemy healths
    public Text playerHealthText;
    public Text enemyHealthText;
    //Character script for player health
    public Character player;
    //Int that stores enemy Health
    public int enemyHealth;
    //Int that displays enemy and player damage dealt
    public int playerDamage;
    public int enemyDamage;

    //Damage minimums for player and enemy.
    public int playerDamageMin;
    public int playerDamageMax;

    //Damage maximums for player and enemy.
    public int enemyDamageMin;
    public int enemyDamageMax;

    //Player and enemy damage 
    //Damage Dealt By The Player
    public TextMeshProUGUI playerDamageText;
    //Damage Dealt By The Enemy
    public TextMeshProUGUI enemyDamageText;
    //Sliders that contain player health and enemy health
    public Slider playerHealthSlider;
    public Slider enemyHealthSlider;
    //Text objects that store information for player health and gold
    [SerializeField] private TextMeshProUGUI playerHealth;
    [SerializeField] private TextMeshProUGUI playerGold;

    //Game objects that controll the UI Elements on the canvas.
    public GameObject boardUI;
    public GameObject playerAttack;
    public GameObject playerCharacter;
    //Text object that indicates player turns
    public Text turnText;

    //Variables that house the events and subscriptions
    public static event System.Action<BasicEnemyTEST> monsterEvent;
    public static event System.Action<GameObject> monsterGameObject;
    public static event System.Action<GameObject> monsterAttack;
    public static event System.Action<GameObject> monsterDeath;
    public static event System.Action<GameObject> playerGO;
    public static event System.Action<GameObject> playerDeath;
    #endregion
    
    //bool doubleDMG;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip takeDamage;



    void Start()
    {
        AkSoundEngine.SetSwitch("Music_Switch", "combat_switch", gameObject);

       
        enemyHealth = monster.HP;
        Debug.Log(enemyHealth);

        //doubleDMG = false;
        playerHealthText.text = player.HP.ToString();
        enemyHealthText.text = enemyHealth.ToString();
        playerHealthSlider.value = player.HP;
        audioSource = GetComponent<AudioSource>();

        

        if (enemyHealthSlider != null)
        {
            enemyHealthSlider.value = enemyHealth;

        }

    }

    // Update is called once per frame
    void Update()
    {
        //Sets enemy health from the BasicTestEnemy to show up
        enemyHealthText.text = enemyHealth.ToString();
        //if the player has less than or equal to 0 health, set this canvas to turn off.
        if (player.HP <= 0)
        {
            this.gameObject.SetActive(false);
           
            
        }

        //Updates player health slider based on player HP.
        playerHealthSlider.value = player.HP;

        //When the enemy health slider isn't null, set it's value equal to enemy health.
        if (enemyHealthSlider != null)
        {
            enemyHealthSlider.value = enemyHealth;
            

        }

        //Updates player health and gold based on information housed in player game object. 
        playerHealth.text = player.HP.ToString();
        playerGold.text = player.gold.ToString();
    }

    public void attack()
    {

        if (enemyHealth > 0)
        {
            //Calls for a random damage between minimum and max.
            playerDamage = UnityEngine.Random.Range(playerDamageMin, playerDamageMax);
            //Player damage is printed to damage text.
            playerDamageText.text = "-" + playerDamage.ToString();

            playerAnim.SetTrigger("Attack");
            ////Player health slider is updated.
            //playerHealthSlider.value = player.HP;



            //Enemy health has player damage subtracted from it. 
            enemyHealth -= playerDamage;
            Debug.Log(enemyHealth);
            Debug.Log(enemyHealthSlider.value);
            
            enemyHealthText.text = enemyHealth.ToString();

            //Calls for the monster game object event to be invoked. 
            monsterGameObject?.Invoke(enemyMonster);


            //Begin turn Coroutine.
            StartCoroutine(turn());

           
        }

        if (enemyHealth <= 0)
        {
            //Reset the turn animations for UI canvas
            turnReset();
            StartCoroutine(enemyDeath());
            

        }
    }

    public IEnumerator turn()
    {
        //turns off player button.
        playerAttack.SetActive(false);
        Debug.Log("Begin Waiting");
        uICanAnim.SetBool("turnIsStarting", true);
        turnText.text = "Enemy Turn!";
        yield return new WaitForSecondsRealtime(5f);
        enemyDamage = UnityEngine.Random.Range(enemyDamageMin, enemyDamageMax);
        
        enemyHealthSlider.value = enemyHealth;
        monsterAttack?.Invoke(enemyMonster);
        

        player.HP -= enemyDamage;
        enemyDamageText.text = "-" + enemyDamage.ToString();

        uICanAnim.SetBool("playerIsDamaged", true);
        playerGO?.Invoke(playerCharacter);
        playerHealthText.text = player.HP.ToString();
        Debug.Log("Stop Waiting");
        if(player.HP > 0)
        {
         turnReset();

        yield return new WaitForSecondsRealtime(1f);

        turnText.text = "Player's Turn!";
        uICanAnim.SetBool("turnIsStarting", true);

        yield return new WaitForSecondsRealtime(2f);
        turnReset();
        playerAttack.SetActive(true);

        }

        if(player.HP <= 0)
        {
            playerDeath?.Invoke(playerCharacter);
        }
       
    }

    public IEnumerator enemyDeath()
    {
        monsterDeath?.Invoke(enemyMonster);
        yield return new WaitForSecondsRealtime(1f);
        //Enable Roll button.
        playerAttack.SetActive(true);
        //Change the camera back to the board camera view. 
        cameras.changeCameras();
        //Resumes the game to keep player from rolling while in combat. 
        sceneManage.ResumeGame();
        //Resets the enemy health to full to not conflict when changing soaces, 
        enemyHealth = monster.HP;
        //Turns off combat canvas
        combatCanvas.SetActive(false);
        //enables board canvas
        boardCanvas.SetActive(true);
        //Enables board UI
        boardUI.SetActive(true);
        //Invokes the Monster Event to reset player scale.
        monsterEvent?.Invoke(monster);

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

    //Decreases the player's max attack. Called via random event
    public void DamageDebuff()
    {
        playerDamageMax -= UnityEngine.Random.Range(1, 3);
        
       if (playerDamageMax <= 0)
        {
            playerDamageMax = 1;
        }

        if (playerDamageMin > playerDamageMax)
        {
            playerDamageMin = playerDamageMax;
        }
    }

    //Doubles the player's damage (doubles the min and max rolls)
    public void DoubleDamage()
    {
        //doubleDMG = true;
        playerDamageMax *= 2;
        playerDamageMin *= 2;
    }


}

