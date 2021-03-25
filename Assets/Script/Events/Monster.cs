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
    public GameObject combatUICanvas;
    public string popUp;


    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip battleStart;

    [SerializeField] private Vector3 originalScale;
    [SerializeField] private Vector3 newScale;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;

    void OnEnable()
    {
        CombatUIManager.monsterEvent += OnMonsterEventHeard;
    }

    void OnDisable()
    {
        CombatUIManager.monsterEvent -= OnMonsterEventHeard;
    }

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
            playerGO.transform.position = new Vector3(playerGO.transform.position.x + offsetX,playerGO.transform.position.y + offsetY, playerGO.transform.position.z + offsetZ);
            audioSource.PlayOneShot(battleStart);
            cameraEvent?.Invoke(cam);
            fightWarnning.SetActive(true);
            basicEnemyTEST.EnemySpawn();
            boardUI.SetActive(false);
            //combatUICanvas.SetActive(true);

            audioSource.PlayOneShot(battleStart);

            //PasueGame();
        }
    }
    void OnMouseDown()
    {
        PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
        pop.PopUp(popUp);
    }

    void OnMonsterEventHeard(BasicEnemyTEST monster)
    {
        playerGO.transform.position = new Vector3(playerGO.transform.position.x, playerGO.transform.position.y, playerGO.transform.position.z);
        playerGO.transform.localScale = originalScale;
    }

    //void PasueGame()
    //{
    //    Time.timeScale = 0;
    //}


}
