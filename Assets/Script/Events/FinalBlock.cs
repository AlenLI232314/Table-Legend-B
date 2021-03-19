using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBlock : MonoBehaviour
{
    public GameObject finalBlock;
    public GameObject boardUI;
    public string popUp;



    void Start()
    {
        finalBlock.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            finalBlock.SetActive(true);
            PasueGame();
            boardUI.SetActive(false);
        }

        void OnMouseDown()
        {
            PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
            pop.PopUp(popUp);
        }
    }
    void PasueGame()
    {
        Time.timeScale = 0;
    }

}
