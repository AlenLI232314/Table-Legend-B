using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int Gold;
    [SerializeField] private int Health;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Character character;
    void Start()
    {
        character = FindObjectOfType<Character>();

    }

    // Update is called once per frame
    void Update()
    {
        Health = character.HP;
        Gold = character.gold;
        goldText.text = Gold.ToString();
        healthText.text = Health.ToString();
    }
}