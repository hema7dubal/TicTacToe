using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour
{
    public WinCondition WinConditionScript;
    public SwitchPlayer SwitchPlayerScript;

    public void ResetGamePlay()
    {
        WinConditionScript.ResetStates();
        SwitchPlayerScript.ResetPlayerStates();
    }
}
