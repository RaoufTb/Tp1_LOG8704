using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_music;

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

    private void Start()
    {
        AudioSource audioSource = Instantiate(m_AudioSource, transform.position, Quaternion.identity);
        audioSource.clip = m_music;
        audioSource.volume = 1f;
        audioSource.loop = true;
        audioSource.spatialize = true;
        audioSource.spatialBlend = 1f;
        audioSource.Play();

    }

    public void playAudio(AudioClip audioClip, Transform position, float volume)
    {
        AudioSource audioSource = Instantiate(m_AudioSource, position.position, Quaternion.identity, transform);

        audioSource.spatialize = true; 
        audioSource.spatialBlend = 1f; 
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        Destroy(audioSource.gameObject, audioClip.length + 0.1f);
    }


    public void playRandomAudio(AudioClip[] audioClips, Transform position, float volume)
    {
        AudioSource audioSource = Instantiate(m_AudioSource, position.position, Quaternion.identity);

        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource, clipLength);
    }
}