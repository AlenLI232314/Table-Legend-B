using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText, turnsText,rollText, coinText, xpText, levelText;

    private int health, turn,xp,coins,level;

    //The position the camera moves to to see the whole map, assigned in-editor for each different level
    public Vector3 wholeMapView;

    //The player/camera game objects, so that the camera can easily return to the player's pos when they're
    //moving around the map. Both assigned in editor

    public GameObject player, camera;

    void Start()
    {
        turn = 1;
        health = 100;
        xp = 0;
        coins = 100;
        level = 1;
        //Sets the health and turn displays and values to default vals
        healthText.SetText("100");
        turnsText.SetText("01");
    }

    //Increments player health with value giveOrTake
    public void ChangeHealth(int giveOrTake)
    {
        health += giveOrTake;
        //Logic to make sure the player's health doesnt go over the max or under the min
        if (health < 0)
        {
            health = 0;
        }
        else if (health > 100)
        {
            health = 100;
        }
        //Logic for formatting, ensuring there's always 3 digits
        if (health < 100)
        {
            if (health < 10)
            {
                healthText.SetText("00" + health.ToString());
            }
            else
            {
                healthText.SetText("0" + health.ToString());
            }
        }
        else
        {
            healthText.SetText("100");
        }
    }

    //Increments the Turn counter with value giveOrTake
    public void ChangeTurn(int giveOrTake)
    {
        turn += giveOrTake;
        //Logic to make sure the current turn doesnt go over the max or under the min
        if (turn < 1)
        {
            turn = 1;
        }
        else if (turn > 99)
        {
            turn = 99;
        }

        //Logic for formatting, ensuring there's always 2 digits
        if (turn < 10)
        {
            turnsText.SetText("0" + turn.ToString());
        }
        else
        {
            turnsText.SetText(turn.ToString());
        }
    }

    //Displays the roll of the dice, based on parameter received from the roller script
    public void showRoll(int roll)
    {
        rollText.SetText(roll.ToString());
    }

    //called when the player receives XP, and updates the xp display
    public void giveXp(int xpToGive)
    {
        int levelsGained = 0;
        xp += xpToGive;

        //calculates how many levels are gained.
        if (xp >= 100)
        {
            //Calculates how many levels the player advances, based on how many times they go over 100 xp
            levelsGained = 100/xp;

            //keeps players xp under 100 if they've received more than 100 xp from a big xp gain
            xp = (100 * levelsGained) - xp;
        }

            
       
        for (int i = 0; i < levelsGained; i++)
        {
            levelUp();
        }

        //ensures the counter is always double digit
        if (xp >= 10)
        {
            xpText.SetText("0" + xp.ToString());
        }
        else
        {
            xpText.SetText("00" + xp.ToString());
        }
        
    }

    //called when the player receives Coins, or gets coins taken away (thru a negative int being passed in) 
    //and updates the coins display
    public void giveOrTakeCoins(int coinsToGiveOrTake)
    {
        coins += coinsToGiveOrTake;

        //keeps coins from going over max/under the min
        if (coins > 999)
        {
            
            coins = 999;
        }
        else if (coins < 0)
        {
            coins = 0;
        }

        //adds a zero to the coin counter if its under 100, to keep it triple digits
        if (coins < 100)
        {
            coinText.SetText("0" + coins.ToString());
        }
        else
        {
            coinText.SetText(coins.ToString());
        }
        
    }

    //Called when Xp reaches >= 100
    public void levelUp()
    {
        level++;
        if (level < 10)
        {
            levelText.SetText("0" + level.ToString());
        }
        else
        {
            levelText.SetText(level.ToString());
        }
    }

    //Called by the map view button to change the position of the camera from player view to map view and vice-versa
    public void changeView()
    {
        //player view is the position of the camera when it's viewing the player. Here it's defined as the current
        //position of the player plus an offset of 3 for each axis.
        //I will need to also figure out how to get the camera rotated the right way as well
        Vector3 playerView = new Vector3(3 + player.transform.position.x, 3 + player.transform.position.y,
            3 + player.transform.position.z);

        //logic for switching between the two views (so it switches between the two with the press of the 
        //map view button)
        if (camera.transform.position == wholeMapView)
        {
            camera.transform.position = playerView;
        }
        else
        {
            camera.transform.position = wholeMapView;
        }
    }

}
