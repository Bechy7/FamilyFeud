using System.Collections.Generic;

public static class GameHelper
{
    public static int round = 1;
    public static int maxRounds = 4;
    private static readonly Dictionary<int, string> questions = new()
    {
        { 1, "Question 1?" },
        { 2, "Question 2?" },
        { 3, "Question 3?" },
        { 4, "Question 4?" },
    };
    private static readonly Dictionary<int, List<string>> answers = new()
    {
        { 1, new List<string> { "Pizza", "Burger", "Pasta", "Sushi", "Tacos", "Salad", "Sandwich" } },
        { 2, new List<string> { "Dog", "Cat", "Fish", "Bird", "Hamster", "Rabbit", "Guinea Pig" } },
        { 3, new List<string> { "Red", "Blue", "Green", "Yellow", "Purple", "Orange", "Pink" } },
        { 4, new List<string> { "Soccer", "Basketball", "Tennis", "Baseball", "Football", "Hockey", "Golf" } },
    };

    public static string GetQuestion()
    {
        return questions[round];
    }

    public static string GetAnswer(int answerIndex)
    {
        return answers[round][answerIndex];
    }
}