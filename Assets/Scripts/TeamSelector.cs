using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamSelector : MonoBehaviour
{
    public GameObject team1Light;
    public GameObject team2Light;
    public Transform team1Viewport;
    public Transform team2Viewport;
    public Image playerPrefab;
    public List<Button> availablePlayers;
    private bool turn1 = true;

    void Start()
    {
        foreach (var player in availablePlayers)
        {
            player.onClick.AddListener(() => AddPlayerToTeam(player));
        }
    }

    public void AddPlayerToTeam(Button player)
    {
        player.gameObject.SetActive(false);
        playerPrefab.sprite = player.GetComponent<Image>().sprite;

        Instantiate(playerPrefab, turn1 ? team1Viewport : team2Viewport);
        TeamManager.AddPlayerToTeam(player.GetComponent<Image>(), turn1);
        ToggleTurn();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    private void ToggleTurn()
    {
        turn1 = !turn1;
        team1Light.SetActive(!team1Light.activeSelf);
        team2Light.SetActive(!team2Light.activeSelf);
    }
}