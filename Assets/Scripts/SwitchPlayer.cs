using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchPlayer : MonoBehaviour
{
    public Text Player1, Player2;
    private bool Player1State, Player2State;
    private string CurrentlyEnabledPlayer;

    public void Start()
    {
        CurrentlyEnabledPlayer = Player1.name;
        Player1State = Player1.enabled;
        Player2State = Player2.enabled;
    }

    public void Switch()
    {
        Player1.enabled = Player1State = !Player1State;
        Player2.enabled = Player2State = !Player2State;
    }

    public string GetCurrentlyEnabledPlayer()
    {
        if (Player1State)
        {
            CurrentlyEnabledPlayer = Player1.text;
        }
        else
        {
            CurrentlyEnabledPlayer = Player2.text;
        }
        return CurrentlyEnabledPlayer;
    }

    public void ResetPlayerStates()
    {
        Player1.gameObject.SetActive(true);
        Player2.gameObject.SetActive(true);
        Player1.enabled = Player1State = true;
        Player2.enabled = Player2State = false;
        CurrentlyEnabledPlayer = Player1.name;
    }
}
