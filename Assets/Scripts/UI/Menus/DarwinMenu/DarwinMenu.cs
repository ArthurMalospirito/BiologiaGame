
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DarwinMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    private string[] _lines;
    private int _currentLine = 0;
    [Header("Audio")]
    private AudioSource audioSource;
    [SerializeField] SoundEffect speekAudio;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartDialog(DialogData data)
    {
        _lines=data.lines;
        _currentLine=0;
        GameManager.Instance.SetPause(true);
        ShowLine();
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            NextLine();
        }
    }
    private void NextLine()
    {
        _currentLine++;
        if (_currentLine>=_lines.Length)
        {
            Close();
            return;
        }
        ShowLine();
    }

    private void ShowLine()
    {
        dialogText.text = _lines[_currentLine];
        audioSource.PlayOneShot(speekAudio.clip,speekAudio.volume);
    }

    private void Close()
    {
        GameManager.Instance.SetPause(false);
        gameObject.SetActive(false);
    }
}