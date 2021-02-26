using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dice { Four, Six, Eight, Ten, Twelve, Twenty };
public class DifferentDiceSides : MonoBehaviour
{
    public int FourSidedDieResult;
    public int SixSidedDieResult;
    public int EightSidedDieResult;
    public int TenSidedDieResult;
    public int TwelveSidedDieResult;
    public int TwentySidedDieResult;

    public int GenericResult;

    public void RollingDice(Dice Die)
    {
        switch (Die)
        {
            case Dice.Four:
                FourSidedDieResult = UnityEngine.Random.Range(1, 5);
                GenericResult = FourSidedDieResult;
                break;

            case Dice.Six:
                SixSidedDieResult = UnityEngine.Random.Range(1, 7);
                GenericResult = SixSidedDieResult;
                break;

            case Dice.Eight:
                EightSidedDieResult = UnityEngine.Random.Range(1, 9);
                GenericResult = EightSidedDieResult;
                break;

            case Dice.Ten:
                TenSidedDieResult = UnityEngine.Random.Range(1, 11);
                GenericResult = TenSidedDieResult;
                break;

            case Dice.Twelve:
                TwelveSidedDieResult = UnityEngine.Random.Range(1, 13);
                GenericResult = TwelveSidedDieResult;
                break;

            case Dice.Twenty:
                TwentySidedDieResult = UnityEngine.Random.Range(1, 21);
                GenericResult = TwentySidedDieResult;
                break;
        }
    }    
}
