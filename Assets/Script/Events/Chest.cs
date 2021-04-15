﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (!IsPointerOverUIObject())
        {
            PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();

            pop.PopUp(popUp);
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

    void PasueGame()
    {
        Time.timeScale = 0;
    }
}
