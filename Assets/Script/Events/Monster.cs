using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Monster : MonoBehaviour
{
    public GameObject fightWarnning;
    public BasicEnemyTEST basicEnemyTEST;
    public CinemachineVirtualCamera cam;
    public static event  System.Action <CinemachineVirtualCamera> cameraEvent;
    public GameObject boardUI;
    public GameObject combatUICanvas;

    void Start()
    {
        fightWarnning.SetActive(false);
        cam.gameObject.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" )
        {
            cameraEvent?.Invoke(cam);
            fightWarnning.SetActive(true);
            basicEnemyTEST.EnemySpawn();
            boardUI.SetActive(false);
            //combatUICanvas.SetActive(true);

            

            //PasueGame();
        }
    }

    //void PasueGame()
    //{
    //    Time.timeScale = 0;
    //}

    
}
