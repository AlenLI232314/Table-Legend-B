using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomTemple : MonoBehaviour
{

    
        public GameObject questionBlock;
        public GameObject boardUI;
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip OpenUI;
        public string popUp;



        //This table is for the event, I couldn't think of other methods, so I use a loot table to do this 
        public int[] table =
        {
        35,//result A
        25,//result B
        18,//result C
        13,//result D
        9,//result F
    };

        public int randomNumber;
        public int total;

        void DrawNumber()
        {

            //The comments are the explaination
            //Draw a random number between 0 and total weight, the total weight is 35+25+18+13+9 = 100
            //If now I draw a number is 67, then 
            //67>35, So result A got passed by
            //then 67-35 = 32, 32>25, result B also passed
            //next 32-25 = 7, 7<18, is in the range, therefore this draw leads to result C

            foreach (var item in table)
            {
                total += item;
                
            }

            randomNumber = UnityEngine.Random.Range(0, total);

        foreach (var weight in table)
            {
                //compare is the random number is <= to current weight
                if (randomNumber <= weight)
                {
                    //set event result
                    Debug.Log("Event result: " + weight);

                }
                else
                {
                    randomNumber -= weight;
                }
            }

        }


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


    }


