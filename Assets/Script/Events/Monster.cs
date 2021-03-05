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

    public AudioSource audioSource;

    public GameObject boardUI;

    void Start()
    {
        fightWarnning.SetActive(false);
        cam.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" )
        {
            cameraEvent?.Invoke(cam);
            fightWarnning.SetActive(true);
            basicEnemyTEST.EnemySpawn();

            audioSource.PlayOneShot(battleBegin);

            boardUI.SetActive(false);



            //PasueGame();
        }
    }

    //void PasueGame()
    //{
    //    Time.timeScale = 0;
    //}

    
}
