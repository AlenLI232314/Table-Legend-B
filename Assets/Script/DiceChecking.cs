using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceChecking : MonoBehaviour
{
	Vector3 diceVelocity;

	// Update is called once per frame
	void FixedUpdate()
	{
		diceVelocity = RollDice.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
		{
			switch (col.gameObject.name)
			{
				case "Side1":
					DiceNumText.diceNumber = 6;
					break;
				case "Side2":
					DiceNumText.diceNumber = 3;
					break;
				case "Side3":
					DiceNumText.diceNumber = 5;
					break;
				case "Side4":
					DiceNumText.diceNumber = 4;
					break;
				case "Side5":
					DiceNumText.diceNumber = 2;
					break;
				case "Side6":
					DiceNumText.diceNumber = 1;
					break;
			}
		}
	}
}
