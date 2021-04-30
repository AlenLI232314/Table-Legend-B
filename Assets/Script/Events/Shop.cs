using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public GameObject shopBlock;
    public GameObject boardUI;
    public string popUp;
    public GameObject toolTipUI;
    [SerializeField] private Animator shopAnimator;




    void Start()
    {
        shopBlock.SetActive(false);
        shopAnimator = shopBlock.GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            boardUI.SetActive(false);
            shopBlock.SetActive(true);
            shopAnimator.SetTrigger("Shop Event Open");
            //PauseGame();
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

    void PasueGame()
    {
        Time.timeScale = 0;
    }
}
