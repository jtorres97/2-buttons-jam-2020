using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;

    [SerializeField] private AudioSource m_menuMusic, m_levelMusic;
    [SerializeField] private AudioSource[] m_sfx;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayMenuMusic()
    {
        m_levelMusic.Stop();
        m_menuMusic.Play();
    }

    public void PlayLevelMusic()
    {
        m_menuMusic.Stop();
        m_levelMusic.Play();
    }

    public void PlaySFX(int sfxToPlay, bool randomPitch = false)
    {
        m_sfx[sfxToPlay].Stop();
        if (randomPitch)
        {
            m_sfx[sfxToPlay].pitch =  Random.Range(0.6f, .9f);
        }
        m_sfx[sfxToPlay].Play();
    }
}