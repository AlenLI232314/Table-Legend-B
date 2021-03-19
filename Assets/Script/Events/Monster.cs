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
    public GameObject playerGO;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip battleStart;
    [SerializeField] private Vector3 originalScale;

    void Start()
    {

        fightWarnning.SetActive(false);
        cam.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        playerGO = GameObject.FindGameObjectWithTag("Player");
        originalScale = playerGO.transform.localScale;
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" )
        {
            playerGO.transform.localScale = new Vector3 (.15f, .3f, .15f);
            audioSource.PlayOneShot(battleStart);
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
