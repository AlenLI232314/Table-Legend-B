using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dice { Four, Six, Eight, Ten, Twelve, Twenty };
public class DifferentDiceSides
{
    public int FourSidedDieResult;
    public int SixSidedDieResult;
    public int EightSidedDieResult;
    public int TenSidedDieResult;
    public int TwelveSidedDieResult;
    public int TwentySidedDieResult;

    public void RollingDice(Dice Die)
    {
        switch (Die)
        {
            case Dice.Four:
                FourSidedDieResult = UnityEngine.Random.Range(1, 5);
                break;

            case Dice.Six:
                SixSidedDieResult = UnityEngine.Random.Range(1, 7);
                break;

            case Dice.Eight:
                EightSidedDieResult = UnityEngine.Random.Range(1, 9);
                break;

            case Dice.Ten:
                TenSidedDieResult = UnityEngine.Random.Range(1, 11);
                break;

            case Dice.Twelve:
                TwelveSidedDieResult = UnityEngine.Random.Range(1, 13);
                break;

            case Dice.Twenty:
                TwentySidedDieResult = UnityEngine.Random.Range(1, 21);
                break;
        }
    }    
}
