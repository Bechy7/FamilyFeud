using System.Collections.Generic;
using UnityEngine.UI;

public static class TeamManager
{
    public static bool team1Turn = true;
    public static string team1Name = "Team 1";
    public static string team2Name = "Team 2";
    public static List<Image> team1Players = new();
    public static List<Image> team2Players = new();

    public static void AddPlayerToTeam(Image player, bool toTeam1)
    {
        if (toTeam1)
        {
            team1Players.Add(player);
        }
        else
        {
            team2Players.Add(player);
        }
    }
}