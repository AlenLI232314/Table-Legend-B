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
    public TextMeshProUGUI DiceText;
    SphereCollider m_Collider;
    public bool isMoving;
    public string popUp;


    //The event are triggerEnter,so I will only enable the collider after the chatacter done moving

     void Start()
     {
        m_Collider = GetComponent<SphereCollider>();
        this.HP = 20;
        this.isAlive = true;
     }

    //roll dice
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& !isMoving)
        {
            Roll();
        }

        //if (Input.GetKeyDown(KeyCode.Q) && !isMoving)
        //{
        //    PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
        //    pop.PopUp(popUp);
        //}
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
