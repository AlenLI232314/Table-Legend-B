using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using Cinemachine;

public class Character : Entity
{
    //tell the character the moving route
    //TODO: Make movement compatible with DifferentDiceSides code
    //TODO: Make enemy base class, can make different enemies from there.

    public Route currentRoute;

    [SerializeField]
    private GameObject CombatUICanvas, DoubleDamagePanel, DamageDebuffPanel, ExtraRollPanel,
        LoseMoneyPanel, GainMoneyPanel, NothingHappensPanel;
    int routePosition;
    public int health;
    public int steps;
    public TextMeshProUGUI DiceText, HealthText, GoldText, TurnsText, XPText, LevelText, TavernHealthText, TavernGoldText,
        ExtraRollText;
    CapsuleCollider m_Collider;
    public bool isMoving;
    public string popUp;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] private AudioClip[] playerMove;
    [SerializeField] private AudioClip[] diceRolls;
    [SerializeField] private Canvas deathCanvas;
    [SerializeField] private int diceMinRoll;
    [SerializeField] private int diceMaxRoll;
    [SerializeField] private Animator uITransitions;
    [SerializeField] private Animator characterAnim;
    [SerializeField] private Animator uICanAnim;

    public CameraManagement cameraManage;
    public CinemachineVirtualCamera IntroCam;
    public static event System.Action<CinemachineVirtualCamera> cameraEvent;

    //Player stats (aside from HP, which is defined below)
    public int gold, xp, level, turnNumber, extraRollAmount;

    public static event System.Action<GameObject> rotationCube;


    //The event are triggerEnter,so I will only enable the collider after the chatacter done moving
    

    void Start()
    {
        turnNumber = 1;
        xp = 23;
        level = 01;
        m_Collider = GetComponent<CapsuleCollider>();
        characterAnim = GetComponent<Animator>();
        this.HP = health;
        this.isAlive = true;

        audioSource.GetComponent<AudioSource>();

        gold = 10;
        UpdatePlayerStats();

        IntroCam.gameObject.SetActive(false);

        cameraEvent?.Invoke(IntroCam);

        AkSoundEngine.SetSwitch("Music_Switch_Pro", "nonCombat_Switch", gameObject);
        AkSoundEngine.PostEvent("Music_Switch_Pro", gameObject);
    }

    //Called in the update method; assigns player UI elements to their correct values
    void UpdatePlayerStats()
    {
        HealthText.SetText(this.HP.ToString());

        TavernHealthText.SetText(this.HP.ToString());

        TavernGoldText.SetText(gold.ToString());

        GoldText.SetText(gold.ToString());

        XPText.SetText(xp.ToString());
        LevelText.SetText(level.ToString());

        TurnsText.SetText(turnNumber.ToString());


    }

    private void Update()
    {
        checkHealth();
        if (extraRollAmount <= 0)
        {
            ExtraRollText.gameObject.SetActive(false);
        }
        UpdatePlayerStats();
    }

    //roll dice
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E)&& !isMoving)
    //    {
    //        //steps = DiceNumText.diceNumber;

    //        steps = UnityEngine.Random.Range(1, 7);
    //        DiceText.text = steps.ToString();
    //        Debug.Log("Dice Number = " + steps);

    //        if (routePosition + steps < currentRoute.childSquareList.Count)
    //        {
    //            StartCoroutine(Move());
    //        }
    //        else
    //        {
    //            Debug.Log("Need to reroll, too many steps you gonna take.");
    //        }
    //    }

    //    //if (Input.GetKeyDown(KeyCode.Q) && !isMoving)
    //    //{
    //    //    PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
    //    //    pop.PopUp(popUp);
    //    //}
    //}

    //public void Roll()
    //{

    //    if (!isMoving)

    //    UpdatePlayerStats();

    //    if (Input.GetKeyDown(KeyCode.E)&& !isMoving)

    //    {
    //        Roll();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "RotationTrigger")
        //{
        //    rotationCube?.Invoke(this.gameObject);
        //    Debug.Log("Rotation Invoked");
        //}

        if (other.tag == "Player")
        {
            //
        }

        if (other.tag == "Music Trigger")
            AkSoundEngine.SetSwitch("Music_Switch_Pro", "combat_switch", gameObject);

        if(other.tag == "NonCombatMusicTrigger")
            AkSoundEngine.SetSwitch("Music_Switch_Pro", "nonCombat_switch", gameObject);

    }


    public void Roll()
    {
        IntroCam.gameObject.SetActive(false);
        cameraManage.resetCamera();

        UpdatePlayerStats();
        //steps = DiceNumText.diceNumber;
        audioSource.PlayOneShot(diceRolls[UnityEngine.Random.Range(0, diceRolls.Length)]);

        steps = UnityEngine.Random.Range(diceMinRoll, diceMaxRoll);
        DiceText.SetText(steps.ToString());


        if (routePosition + steps < currentRoute.childSquareList.Count)
        {
            turnNumber++;
            StartCoroutine(waitForSound());
            //StartCoroutine(Move());
        }
        else
        {
            Debug.Log("Need to reroll, too many steps you gonna take.");
        }
    }


    //set the method to tell character move when roll a dice
    IEnumerator Move()
    {
        //don't do any movement when character is already moving
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        if (isMoving == true)
        {


            m_Collider.enabled = false;
        }

        //moving method
        while (steps > 0)
        {

            Vector3 nextPos = currentRoute.childSquareList[routePosition + 1].position;
            while (MovingToNext(nextPos))
            {

                yield return null;

            }
            audioSource.PlayOneShot(playerMove[UnityEngine.Random.Range(0, playerMove.Length)]);
            yield return new WaitForSeconds(0.1f);

            if (extraRollAmount > 0)
            {
                extraRollAmount--;
                ExtraRollText.SetText("+" + extraRollAmount.ToString());
            }
            else
            {
                steps--;
                DiceText.SetText(steps.ToString());
            }
            routePosition++;

        }

        isMoving = false;

        if (isMoving == false)
        {
            DiceText.SetText("Roll!");
            m_Collider.enabled = true;
        }

    }

    bool MovingToNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 4f * Time.deltaTime));
    }

    public IEnumerator waitForSound()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        StartCoroutine(Move());
    }

    public void checkHealth()
    {
        if (this.HP <= 0)
        {
            deathCanvas.gameObject.SetActive(true);

        }
    }

    void OnEnable()
    {
        CombatUIManager.playerGO += OnPlayerDamaged;
        CombatUIManager.playerDeath += OnPlayerDeath;

    }

    //Handles the stat effects given to the player when they land on a chance space, based on the int passed in
    public void ChanceEvent(int eventNum)
    {
        switch (eventNum)
        {
            case 1:
                CombatUICanvas.GetComponent<CombatUIManager>().DamageDebuff();
                DamageDebuffPanel.SetActive(true);
                uITransitions.SetTrigger("Open");
                break;
            case 2:
                CombatUICanvas.GetComponent<CombatUIManager>().DoubleDamage();
                DoubleDamagePanel.SetActive(true);
                uITransitions.SetTrigger("Open");
                break;
            case 3:
            case 8:
                extraRollAmount = 3;
                ExtraRollPanel.SetActive(true);
                ExtraRollText.gameObject.SetActive(true);
                uITransitions.SetTrigger("Open");
                break;
            case 4:
            case 9:
                gold -= 10;
                LoseMoneyPanel.SetActive(true);
                uITransitions.SetTrigger("Open");
                break;
            case 5:
            case 10:
                gold += 10;
                GainMoneyPanel.SetActive(true);
                uITransitions.SetTrigger("Open");
                break;


            default:
                NothingHappensPanel.SetActive(true);
                uITransitions.SetTrigger("Open");
                break;
        }
        UpdatePlayerStats();
    }
    void OnPlayerDamaged(GameObject player)
    {
        characterAnim = player.gameObject.GetComponent<Animator>();
        characterAnim.SetTrigger("Damaged");
    }

    void OnPlayerDeath(GameObject player)
    {
        characterAnim = player.gameObject.GetComponent<Animator>();
        characterAnim.SetTrigger("Died");
        isAlive = false;
    }

   

}
