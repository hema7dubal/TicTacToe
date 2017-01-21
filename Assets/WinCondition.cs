using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class WinCondition : MonoBehaviour
{
    private static int moveCount = 0;
    public static WinCondition Instance;
    private string Winner;
    public GameObject WinText;
    public GameObject Player1, Player2, ResetButton;
    private Sprite currentPlayer;
    public Sprite InitialSprite;

    private Button[] AllButtons;
    private List<List<Button>> CurrentlyAppearingIn;
    private List<List<Button>> AllWinConditionsList;

    public List<Button> HorizontalWinCondition1;
    public List<Button> HorizontalWinCondition2;
    public List<Button> HorizontalWinCondition3;

    public List<Button> VerticalWinCondition1;
    public List<Button> VerticalWinCondition2;
    public List<Button> VerticalWinCondition3;

    public List<Button> DiagonalWinCondition1;
    public List<Button> DiagonalWinCondition2;

    private List<Button> WinConditionArray;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetInitialStates();
    }

    public void CheckButtonAppearanceInLists(Button currentButton)
    {
        moveCount++;
        CurrentlyAppearingIn.Clear();
        currentPlayer = currentButton.GetComponent<Image>().sprite;

        foreach (List<Button> eachWinCondition in AllWinConditionsList)
        {
            foreach (Button eachButton in eachWinCondition)
            {
                if (eachButton == currentButton)
                {
                    CurrentlyAppearingIn.Add(eachWinCondition);
                    break;
                }
            }
        }
        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        foreach (List<Button> eachList in CurrentlyAppearingIn)
        {
            WinConditionArray.Clear();
            foreach (Button eachButton in eachList)
            {
                if (eachButton.interactable == false && eachButton.GetComponent<Image>().sprite == currentPlayer)
                {
                    WinConditionArray.Add(eachButton);
                    if (WinConditionArray.Count == 3)
                    {
                        WinText.SetActive(true);
                        if (currentPlayer.name == PlayerType.Cross.ToString())
                            Winner = PlaceContent.crossPlayer.name;
                        else
                            Winner = PlaceContent.roundPlayer.name;

                        WinText.GetComponent<Text>().text = Winner + "Wins";
                        GameOver();
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void GameOver()
    {
        foreach (Button button in AllButtons)
        {
            button.interactable = false;
            HidePlayerTexts();
            ResetButton.SetActive(true);
        }
    }

    void Update()
    {
        if (moveCount == 9)
        {
            WinText.SetActive(true);
            WinText.GetComponent<Text>().text = "Draw!";
            HidePlayerTexts();
            ResetButton.SetActive(true);
        }
    }

    private void HidePlayerTexts()
    {
        Player1.SetActive(false);
        Player2.SetActive(false);
    }

    void SetInitialStates()
    {
        WinConditionArray = new List<Button>();
        ResetButton.SetActive(false);
        AllButtons = GetComponentsInChildren<Button>(true);

        AllWinConditionsList = new List<List<Button>>();
        CurrentlyAppearingIn = new List<List<Button>>();

        AllWinConditionsList.Add(HorizontalWinCondition1);
        AllWinConditionsList.Add(HorizontalWinCondition2);
        AllWinConditionsList.Add(HorizontalWinCondition3);

        AllWinConditionsList.Add(VerticalWinCondition1);
        AllWinConditionsList.Add(VerticalWinCondition2);
        AllWinConditionsList.Add(VerticalWinCondition3);

        AllWinConditionsList.Add(DiagonalWinCondition1);
        AllWinConditionsList.Add(DiagonalWinCondition2);
    }

    public void ResetStates()
    {
        WinConditionArray.Clear();
        moveCount = 0;
        foreach (Button button in AllButtons)
        {
            button.gameObject.GetComponent<Image>().sprite = InitialSprite;
            button.interactable = true;
        }
        CurrentlyAppearingIn.Clear();
        WinText.SetActive(false);
        ResetButton.SetActive(false);
    }
}
