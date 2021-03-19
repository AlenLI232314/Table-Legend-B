using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestBlock;
    public AudioSource audioSource;
    [SerializeField] private AudioClip[] money;
    public GameObject boardUI;
    public string popUp;
    [SerializeField] private Character character;
    [SerializeField] private int goldCount;



    void Start()
    {
        chestBlock.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        character = FindObjectOfType<Character>();
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            chestBlock.SetActive(true);
            PasueGame();
            audioSource.PlayOneShot(money[UnityEngine.Random.Range(0, money.Length)]);
            boardUI.SetActive(false);
            character.gold += goldCount;

        }
    }
    void OnMouseDown()
    {
        PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
        pop.PopUp(popUp);
    }
    void PasueGame()
    {
        Time.timeScale = 0;
    }
}
