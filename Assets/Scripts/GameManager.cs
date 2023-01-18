using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI turnText;

    public GameObject endGameState;

    public TextMeshProUGUI[] tileList;
    public enum PlayerType {X,O}
    public PlayerType whoPlaysFirst;

    private string playerTurn;
    private int moveCount;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn = whoPlaysFirst.ToString();
        if (playerTurn == "X")
        {
            turnText.text = "Player 1's turn";
        }
        else
        {
            turnText.text = "Player 2's turn";
        }
    }

    public void NextTurn()
    {
        moveCount++;
        if (tileList[0].text == playerTurn && tileList[1].text == playerTurn && tileList[2].text == playerTurn)
        {
            GameOver(playerTurn);
        }
        else if (tileList[3].text == playerTurn && tileList[4].text == playerTurn && tileList[5].text == playerTurn)
        {
            GameOver(playerTurn);
        }
        else if (tileList[6].text == playerTurn && tileList[7].text == playerTurn && tileList[8].text == playerTurn)
        {
            GameOver(playerTurn);
        }
        else if (tileList[0].text == playerTurn && tileList[3].text == playerTurn && tileList[6].text == playerTurn)
        {
            GameOver(playerTurn);
        }
        else if (tileList[1].text == playerTurn && tileList[4].text == playerTurn && tileList[7].text == playerTurn)
        {
            GameOver(playerTurn);
        }
        else if (tileList[2].text == playerTurn && tileList[5].text == playerTurn && tileList[8].text == playerTurn)
        {
            GameOver(playerTurn);
        }
        else if (tileList[0].text == playerTurn && tileList[4].text == playerTurn && tileList[8].text == playerTurn)
        {
            GameOver(playerTurn);
        }
        else if (tileList[2].text == playerTurn && tileList[4].text == playerTurn && tileList[6].text == playerTurn)
        {
            GameOver(playerTurn);
        }
        else if (moveCount >= 9)
        {
            GameOver("D");
        }
        else
        {
            SwitchTurn();
        }
    }

    public void SwitchTurn()
    {
        playerTurn = (playerTurn == "X") ? "O" : "X";
        if (playerTurn == "X")
        {
            turnText.text = "Player 1's turn";
        }
        else
        {
            turnText.text = "Player 2's turn";
        }
    }

    private void GameOver(string winningPlayer)
    {
        switch (winningPlayer)
        {
            case "D":
                winnerText.text = "DRAW";
                break;
            case "X":
                winnerText.text = "Player 1 wins!";
                break;
            case "O":
                winnerText.text = "Player 2 wins!";
                break;
        }
        endGameState.SetActive(true);
        ToggleButtonState(false);
    }

    public void RestartGame()
    {
        moveCount = 0;
        playerTurn = whoPlaysFirst.ToString();
        ToggleButtonState(true);
        endGameState.SetActive(false);

        for (int i = 0; i < tileList.Length; i++)
        {
            tileList[i].GetComponentInParent<TileManager>().ResetTileText();
        }
    }

    private void ToggleButtonState(bool state)
    {
        for (int i = 0; i < tileList.Length; i++)
        {
            tileList[i].GetComponentInParent<Button>().interactable = state;
        }
    }

    public string GetPlayersTurn()
    {
        return playerTurn;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
