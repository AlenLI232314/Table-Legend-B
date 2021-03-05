using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    /// <summary>
    /// Responsible for hiding and showing the inventory when the inventory button is pressed
    /// </summary>
    /// 
    private GameManager gameManager;
    private Button thisButton;

    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        //assigns the button (which you attatch this script to) and the gamemanager
        thisButton = GetComponent<Button>();

        thisButton.onClick.AddListener(Clicked);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Called when this button is clicked
    void Clicked()
    {
        //Sets the inventory to the opposite of its current state
        inventory.SetActive(!inventory.activeSelf);
    }
}
