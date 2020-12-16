using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private SceneTransitioner m_sceneTransitioner;
    [SerializeField] private GameObject m_optionsPanel;
    [SerializeField] private GameObject m_howToPlayPanel;
    [SerializeField] private Slider m_musicVolSlider;
    [SerializeField] private Slider m_sfxVolSlider;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("SliderMusicVolumeLevel") && !PlayerPrefs.HasKey("SliderSFXVolumeLevel"))
        {
            PlayerPrefs.SetFloat("SliderMusicVolumeLevel", -20);
            PlayerPrefs.SetFloat("SliderSFXVolumeLevel", -20);
        }
    }

    private void Start()
    {
        SoundController.Instance.PlayMenuMusic();
    }

    private void Update()
    {
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        m_musicVolSlider.value = PlayerPrefs.GetFloat("SliderMusicVolumeLevel");
        m_sfxVolSlider.value = PlayerPrefs.GetFloat("SliderSFXVolumeLevel");
    }

    public void StartGame()
    {
        m_sceneTransitioner.Transition();
        SoundController.Instance.PlayLevelMusic();
    }

    public void OpenOptionsPanel()
    {
        m_optionsPanel.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        m_optionsPanel.SetActive(false);
        PlayerPrefs.Save();
    }

    public void ShowHowToPlayPanel()
    {
        m_howToPlayPanel.SetActive(true);
    }
    
    public void HideHowToPlayPanel()
    {
        m_howToPlayPanel.SetActive(false);
    }
}
