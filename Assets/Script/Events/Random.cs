using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    public GameObject questionBlock;



    void Start()
    {
        questionBlock.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            questionBlock.SetActive(true);
            PasueGame();
        }
    }
    void PasueGame()
    {
        Time.timeScale = 0;
    }

    internal static int Range(int v)
    {
        throw new NotImplementedException();
    }
}
