using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopBlock;
    public GameObject boardUI;

    void Start()
    {
        shopBlock.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            boardUI.SetActive(false);
            shopBlock.SetActive(true);
            //PauseGame();
        }
    }

    //void PauseGame()
    //{
    //    Time.timeScale = 0;
    //}
}
