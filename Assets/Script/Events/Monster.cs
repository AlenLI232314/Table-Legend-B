using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Monster : MonoBehaviour
{
    public GameObject fightWarnning;
    public BasicEnemyTEST basicEnemyTEST;
    public CinemachineVirtualCamera cam;
    public static event  System.Action <CinemachineVirtualCamera> cameraEvent;
    public GameObject boardUI;
    public GameObject playerGO;
    //public GameObject combatUICanvas;
    public string popUp;

    public CombatUIManager combatManager;

    public GameObject toolTipUI;

    [SerializeField] private Vector3 transformOriginal;
    public Animator monsterAnim;
    public GameObject monster;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip battleStart;

    [SerializeField] private Slider monsterSlider;
    [SerializeField] private TextMeshProUGUI monsterDamage;

    [SerializeField] private Vector3 originalScale;
    [SerializeField] private Vector3 newScale;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;

    

    [SerializeField] private float returnOffSety;

    void OnEnable()
    {
        CombatUIManager.monsterEvent += OnMonsterEventHeard;
        CombatUIManager.monsterGameObject += OnMonsterDamaged;
        CombatUIManager.monsterAttack += MonsterAttack;
        CombatUIManager.monsterDeath += MonsterDeath;
        
    }

    void OnDisable()
    {
        CombatUIManager.monsterEvent -= OnMonsterEventHeard;
        CombatUIManager.monsterGameObject -= OnMonsterDamaged;
        CombatUIManager.monsterAttack -= MonsterAttack;
        CombatUIManager.monsterDeath -= MonsterDeath;
        

    }

    void Start()
    {
        
        combatManager.enemyHealthSlider = monsterSlider;
        fightWarnning.SetActive(false);
        cam.gameObject.SetActive(false);

        basicEnemyTEST = FindObjectOfType<BasicEnemyTEST>();


        audioSource = GetComponent<AudioSource>();

        playerGO = GameObject.FindGameObjectWithTag("Player");
        originalScale = playerGO.transform.localScale;
        transformOriginal = new Vector3(playerGO.transform.position.x, playerGO.transform.position.y, playerGO.transform.position.z);
   
    }

    void Update()
    {
        transformOriginal = new Vector3(playerGO.transform.position.x, playerGO.transform.position.y, playerGO.transform.position.z);

    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" )
        {
            monsterAnim = monster.gameObject.GetComponent<Animator>();
            monsterAnim.SetTrigger("Spawning");
            combatManager.enemyMonster = monster;
            combatManager.playerDamageText = monsterDamage;
            playerGO.transform.localScale = newScale;
            playerGO.transform.position = new Vector3(playerGO.transform.position.x + offsetX,playerGO.transform.position.y + offsetY, playerGO.transform.position.z + offsetZ);
            audioSource.PlayOneShot(battleStart);
            cameraEvent?.Invoke(cam);
            fightWarnning.SetActive(true);
            basicEnemyTEST.EnemySpawn();
            combatManager.enemyMonster = monster;
            combatManager.enemyHealthSlider = monsterSlider;
            boardUI.SetActive(false);
            //combatUICanvas.SetActive(true);

            audioSource.PlayOneShot(battleStart);
            toolTipUI.SetActive(false);

            //PasueGame();
        }
    }
    void OnMouseDown()
    {
        PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
        if (!IsPointerOverUIObject())
        {
            if(popUp != null && !combatManager.gameObject.activeInHierarchy)
            {
              

                pop.PopUp(popUp);
            }
            
        }

    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


    void OnMonsterEventHeard(BasicEnemyTEST monster)
    {
        playerGO.transform.position = new Vector3(transformOriginal.x, transformOriginal.y, transformOriginal.z);
            //new Vector3(playerGO.transform.position.x - offsetX, playerGO.transform.position.y - offsetY, playerGO.transform.position.z - offsetZ);
        playerGO.transform.localScale = originalScale;
    }

    void OnMonsterDamaged(GameObject monster)
    {
        monsterAnim = monster.gameObject.GetComponent<Animator>();
        monsterAnim.SetTrigger("Damaged");
    }

    void MonsterAttack(GameObject monster)
    {
        monsterAnim = monster.gameObject.GetComponent<Animator>();
        monsterAnim.SetTrigger("Attacked");
    }

    void MonsterDeath(GameObject monster)
    {
        monsterAnim = monster.gameObject.GetComponent<Animator>();
        monsterAnim.SetTrigger("Died");
        toolTipUI.SetActive(true);
    }

  
    //void PasueGame()
    //{
    //    Time.timeScale = 0;
    //}


}
