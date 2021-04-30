using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinalBlock : MonoBehaviour
{
    public GameObject finalBlock;
    public GameObject boardUI;
    public string popUp;
    public GameObject toolTipUI;
    [SerializeField] private Animator finalEventController;



    void Start()
    {
        finalBlock.SetActive(false);
        finalEventController = finalBlock.GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            finalBlock.SetActive(true);
            finalEventController.SetTrigger("Final Event Open");
            //PauseGame();
            boardUI.SetActive(false);
            toolTipUI.SetActive(false);
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
    void PauseGame()
    {
        Time.timeScale = 0;
    }

}
