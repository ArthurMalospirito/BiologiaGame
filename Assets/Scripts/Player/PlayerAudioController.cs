

using UnityEngine;

public class PlayerAudioController :MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private SoundEffect damageAudio;


    public void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    public void OnDamage()
    {
        audioSource.PlayOneShot(damageAudio.clip,damageAudio.volume);
    }
}