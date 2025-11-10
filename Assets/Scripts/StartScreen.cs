using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public Button startButton;

    public void StartButtonClicked()
    {
        SceneManager.LoadScene("TeamSelector");
    }
}