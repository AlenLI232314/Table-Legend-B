using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBlock : MonoBehaviour
{
    public GameObject finalBlock;



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
        }

        
    }
    void PasueGame()
    {
        Time.timeScale = 0;
    }

}
