using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopBlock;
    public GameObject boardUI;
    public string popUp;




    void Start()
    {
        shopBlock.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            boardUI.SetActive(false);
            shopBlock.SetActive(true);
            //PauseGame();
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
