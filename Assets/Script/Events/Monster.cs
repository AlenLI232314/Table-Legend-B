using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject fightWarnning;
    
    

    void Start()
    {
        fightWarnning.SetActive(false);   
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" )
        {
            fightWarnning.SetActive(true);
            PasueGame();
        }
    }

    void PasueGame()
    {
        Time.timeScale = 0;
    }

    
}
