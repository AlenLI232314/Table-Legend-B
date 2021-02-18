using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject fightWarnning;
    bool isMoving;
    

    void Start()
    {
        fightWarnning.SetActive(false);   
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && !isMoving)
        {
            fightWarnning.SetActive(true);
        }
    }
}
