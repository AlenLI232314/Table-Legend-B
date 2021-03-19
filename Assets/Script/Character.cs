using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Character : Entity
{
    //tell the character the moving route
    //TODO: Make movement compatible with DifferentDiceSides code
    //TODO: Make enemy base class, can make different enemies from there.

    public Route currentRoute;
    int routePosition;
    public int health;
    public int steps;
    public TextMeshProUGUI DiceText, HealthText, GoldText, TurnsText, XPText, LevelText;
    SphereCollider m_Collider;
    public bool isMoving;
    public string popUp;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] private AudioClip[] playerMove;
    [SerializeField] private AudioClip[] diceRolls;
    [SerializeField] private Canvas deathCanvas;
    [SerializeField] private int diceMinRoll;
    [SerializeField] private int diceMaxRoll;
    //Player stats (aside from HP, which is defined below)
    public int gold, xp, level, turnNumber;


    //The event are triggerEnter,so I will only enable the collider after the chatacter done moving

     void Start()
     {
        turnNumber = 1;
        xp = 23;
        level = 01;
        m_Collider = GetComponent<SphereCollider>();
        this.HP = health;
        this.isAlive = true;

        audioSource.GetComponent<AudioSource>();

        gold = 10;
        TurnsText.SetText("01");

     }

    //Called in the update method; assigns player UI elements to their correct values
    void UpdatePlayerStats()
    {
        HealthText.SetText(this.HP.ToString());
        
        GoldText.SetText(gold.ToString());

        XPText.SetText(xp.ToString());
        LevelText.SetText(level.ToString());

        TurnsText.SetText(turnNumber.ToString());
    }

    private void Update()
    {
        checkHealth();
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




    //Rolls the dice. Called when the player either presses the roll button or the E key
    public void Roll()
    {
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
            steps--;
            DiceText.SetText(steps.ToString());

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
        if(this.HP <= 0)
        {
            deathCanvas.gameObject.SetActive(true);
        }
    }
}
