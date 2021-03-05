using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestBlock;
    public AudioSource audioSource;
    [SerializeField] private AudioClip[] money;
    [SerializeField] private AudioClip[] chest;


    void Start()
    {
        chestBlock.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            chestBlock.SetActive(true);
            PasueGame();
            audioSource.PlayOneShot(chest[UnityEngine.Random.Range(0, chest.Length)]);
            audioSource.PlayOneShot(money[UnityEngine.Random.Range(0, money.Length)]);
        }
    }
    void PasueGame()
    {
        Time.timeScale = 0;
    }
}
