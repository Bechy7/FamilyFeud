using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameScreen : MonoBehaviour
{
    public TMP_Text questionText;
    public List<Button> questionButtons;
    public Button ErrorButton;
    public TMP_Text teamText;
    public Image currentPlayerImage;
    private int currentPlayerIndex = 0;
    public List<Image> errorIndicators;
    private int errorCount = 0;
    public TMP_Text nextRoundText;
    void Start()
    {
        questionText.text = GameHelper.GetQuestion();
        nextRoundText.text = GameHelper.round >= GameHelper.maxRounds ? "End Game" : "Next Round";
        UpdateCurrentPlayer();
        foreach (var button in questionButtons)
        {
            button.onClick.AddListener(() => ButtonClicked(button, questionButtons.IndexOf(button)));
        }
    }

    private void ButtonClicked(Button button, int position)
    {
        var buttonImage = button.GetComponent<Image>();
        Color newColor = buttonImage.color;
        newColor.a = 1f;
        buttonImage.color = newColor;

        button.GetComponentInChildren<TextMeshProUGUI>().text = GameHelper.GetAnswer(position);
        UpdateCurrentPlayer();
    }

    public void UpdateCurrentPlayer()
    {
        teamText.text = TeamManager.team1Turn ? TeamManager.team1Name : TeamManager.team2Name;
        List<Image> players = TeamManager.team1Turn ? TeamManager.team1Players : TeamManager.team2Players;
        if (players.Count == 0) return;

        currentPlayerImage.sprite = players[currentPlayerIndex].sprite;
        if (currentPlayerIndex < players.Count - 1)
        {
            currentPlayerIndex++;
        }
        else
        {
            currentPlayerIndex = 0;
        }
    }

    public void NextRoundClicked()
    {
        if (GameHelper.round >= GameHelper.maxRounds)
        {
            SceneManager.LoadScene("EndScreen");
            return;
        }

        GameHelper.round++;
        TeamManager.team1Turn = GameHelper.round % 2 != 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Error()
    {
        var buttonImage = errorIndicators[errorCount].GetComponent<Image>();
        Color newColor = buttonImage.color;
        newColor.a = 1f;
        buttonImage.color = newColor;
        errorCount++;

        if (errorCount >= 3)
        {
            TeamManager.team1Turn = !TeamManager.team1Turn;
            currentPlayerIndex = 0;
            ErrorButton.interactable = false;
        }

        UpdateCurrentPlayer();
    }
}