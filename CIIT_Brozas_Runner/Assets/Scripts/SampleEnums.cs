using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnums : MonoBehaviour
{
    public enum DiceState
    {
        isThrown,
        isSleeping,
    }

    public DiceState diceState;

    private void Update()
    {
        switch(diceState)
        {
            case DiceState.isSleeping:
                break;

            case DiceState.isThrown:
                break;
        }
    }
}
