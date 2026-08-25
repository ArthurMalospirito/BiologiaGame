using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    
    public void OnStart()
    {
        SceneManager.LoadScene("Main",LoadSceneMode.Single);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
