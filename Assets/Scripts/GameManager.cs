using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsPaused {get; private set;}

    public void SetPause(bool pauseState)
    {
        IsPaused = pauseState;
        Time.timeScale= pauseState ? 0f : 1f;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
