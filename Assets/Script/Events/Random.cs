using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    public GameObject questionBlock;
    public GameObject boardUI;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip OpenUI;
    public string popUp;


    void Start()
    {
        questionBlock.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            questionBlock.SetActive(true);
            boardUI.SetActive(false);
            audioSource.PlayOneShot(OpenUI);
            PasueGame();
        }
    }
    void PasueGame()
    {
        Time.timeScale = 0;
    }

    void OnMouseDown()
    {
        PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
        pop.PopUp(popUp);
    }
    internal static int Range(int v)
    {
        throw new NotImplementedException();
    }
}
