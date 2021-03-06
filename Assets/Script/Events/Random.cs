﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Random : MonoBehaviour
{
    public GameObject questionBlock;
    public GameObject boardUI;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int RandomRoll; 

    [SerializeField] private AudioClip OpenUI;
    [SerializeField] private Animator randomAnimator;
    public string popUp;
    public GameObject toolTipUI;





    void Start()
    {
        questionBlock.SetActive(false);
        randomAnimator = questionBlock.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            questionBlock.SetActive(true);
            randomAnimator.SetTrigger("Open");
            boardUI.SetActive(false);
            audioSource.PlayOneShot(OpenUI);
            //PasueGame();
            toolTipUI.SetActive(false);
        }

        return;
    }
    void PasueGame()
    {
        Time.timeScale = 0;
    }

    
    void DiceRoll()
    {
        RandomRoll = UnityEngine.Random.Range(1, 100);
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


}
