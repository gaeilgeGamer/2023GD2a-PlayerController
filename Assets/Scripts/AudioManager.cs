using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip jumpClip;
    public AudioClip dashClip;
    public AudioClip footstepSound;
    public AudioClip attackSound;
    public AudioClip backgroundMusic;

    private AudioSource soundEffectSource; // For player sounds
    private AudioSource backgroundMusicSource; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Initialize audio sources
        soundEffectSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();

        // Configure background music source
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;  
        backgroundMusicSource.Play();  
    }

    // Play methods for sound effects
    public void PlayJumpSound()
    {
        soundEffectSource.PlayOneShot(jumpClip);
    }

    public void PlayDashSound()
    {
        soundEffectSource.PlayOneShot(dashClip);
    }

    public void PlayFootstepSound()
    {
        soundEffectSource.PlayOneShot(footstepSound);
    }

    public void PlayAttackSound()
    {
        soundEffectSource.PlayOneShot(attackSound);
    }

    // Methods for controlling the background music
    public void PlayBackgroundMusic()
    {
        if (!backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
        }
    }

    public void PauseBackgroundMusic()
    {
        backgroundMusicSource.Pause();
    }

    public void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
    }
}
