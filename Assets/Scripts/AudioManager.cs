using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    private static AudioManager instance;

    public AudioSource bgAudioSource;
    public AudioSource audioSource;
    public AudioClip fireClip;
    //public AudioClip idleClip;
    //public AudioClip rotateClip;
    public AudioClip destroyClip;

    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void PlayEffectMusic(AudioClip clip)
    {
        if (!GameManager.Instance.isGameOver)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void CloseBGMusic()
    {
        bgAudioSource.enabled = false;
    }

}
