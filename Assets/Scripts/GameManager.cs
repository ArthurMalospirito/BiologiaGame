#if UNITY_EDITOR
    using UnityEditor;
#endif

using Enums.EnumMovementType;
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

    private void Start()
    {
        #if UNITY_EDITOR
            PlayerMovement.currentMovementType = EditorUserBuildSettings.activeBuildTarget==BuildTarget.Android ? MovementType.EightDirection : MovementType.SeekMouse;
        #else 
            PlayerMovement.currentMovementType=Application.isMobilePlatform ? MovementType.EightDirection : MovementType.SeekMouse;
        #endif
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
