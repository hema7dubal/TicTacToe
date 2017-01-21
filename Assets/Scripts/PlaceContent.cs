using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum PlayerType
{
    Cross,
    Round
}

public class PlaceContent : MonoBehaviour
{
    public Text Player1, Player2;
    public GameObject PlayerParent;
    public Sprite Cross, Round;
    private string CurrentlyActivePlayer;
    private Button CurrentButton;
    public static GameObject crossPlayer, roundPlayer;
    public PlayerType playerType;
    public SwitchPlayer switchPlayer;

    public void Start()
    {
        CurrentButton = GetComponent<Button>();
        crossPlayer = Player1.gameObject;
        roundPlayer = Player2.gameObject;
    }

    public void ContentTouched()
    {
        CurrentlyActivePlayer = PlayerParent.GetComponent<SwitchPlayer>().GetCurrentlyEnabledPlayer();
        if (CurrentlyActivePlayer == Player1.text)
        {
            GetComponent<Image>().sprite = Cross;
        }
        else
        {
            GetComponent<Image>().sprite = Round;
        }
        CurrentButton.interactable = false;
        WinCondition.Instance.CheckButtonAppearanceInLists(CurrentButton);
        switchPlayer.Switch();
    }
}
