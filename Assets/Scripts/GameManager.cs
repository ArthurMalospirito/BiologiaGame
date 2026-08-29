using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public bool IsPaused {get; private set;}

    private void Awake()
    {
        Instance=this;
    }

    public void SetPause(bool pauseState)
    {
        IsPaused = pauseState;
        Time.timeScale= pauseState ? 0f : 1f;
    }

    public void OpenStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
