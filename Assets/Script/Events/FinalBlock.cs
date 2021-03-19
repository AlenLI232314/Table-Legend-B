using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBlock : MonoBehaviour
{
    public GameObject finalBlock;
    public GameObject boardUI;



    void Start()
    {
        finalBlock.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            finalBlock.SetActive(true);
            PasueGame();
            boardUI.SetActive(false);
        }

        
    }
    void PasueGame()
    {
        Time.timeScale = 0;
    }

}
