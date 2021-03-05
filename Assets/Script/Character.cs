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
    public int steps;
    public TextMeshProUGUI DiceText, HealthText, GoldText, TurnsText, XPText, LevelText;
    SphereCollider m_Collider;
    public bool isMoving;
    public string popUp;

    //Player stats (aside from HP, which is defined below)
    private int gold, xp, level, turnNumber;


    //The event are triggerEnter,so I will only enable the collider after the chatacter done moving

     void Start()
     {
        turnNumber = 1;
        xp = 23;
        level = 01;
        m_Collider = GetComponent<SphereCollider>();
        this.HP = 20;
        this.isAlive = true;

        

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

    public void Roll()
    {

        if (!isMoving)

        UpdatePlayerStats();

        if (Input.GetKeyDown(KeyCode.E)&& !isMoving)

        {
            Roll();
        }
    }




    //Rolls the dice. Called when the player either presses the roll button or the E key
    public void Roll()
    {
        //steps = DiceNumText.diceNumber;

        steps = UnityEngine.Random.Range(1, 7);
        DiceText.SetText(steps.ToString());
        Debug.Log("Dice Number = " + steps);

        if (routePosition + steps < currentRoute.childSquareList.Count)
        {
            turnNumber++;
            StartCoroutine(Move());
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
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;

        }
        
        isMoving = false;

        if (isMoving == false)
        {
            m_Collider.enabled = true;
        }

    }

    bool MovingToNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 4f * Time.deltaTime));
    }
}
