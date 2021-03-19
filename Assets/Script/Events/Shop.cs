using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopBlock;



    void Start()
    {
        shopBlock.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            shopBlock.SetActive(true);
            PasueGame();
        }
    }

    void PasueGame()
    {
        Time.timeScale = 0;
    }
}
