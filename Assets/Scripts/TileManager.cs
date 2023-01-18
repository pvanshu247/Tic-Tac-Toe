using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileManager : MonoBehaviour
{
    public GameManager gameManager;
    TextMeshProUGUI tileText;
    Button tileButton;

    private void Start()
    {
        tileButton = GetComponent<Button>();
        tileText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void TileState()
    {
        tileText.text = gameManager.GetPlayersTurn();
        tileButton.interactable = false;
        gameManager.NextTurn();
    }

    public void ResetTileText()
    {
        tileText.text = "";
    }
}
