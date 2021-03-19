using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int Gold;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Character character;

    void Start()
    {
        character = FindObjectOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        Gold = character.gold;
        goldText.text = Gold.ToString();
    }
}
