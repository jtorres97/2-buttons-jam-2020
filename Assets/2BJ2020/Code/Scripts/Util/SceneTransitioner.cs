using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SceneTransitioner : MonoBehaviour
{
    [SerializeField] private string m_sceneToLoad;
    [SerializeField] private float m_transitionSpeed = 2f;
    [SerializeField] private Sprite[] m_transitions;

    private bool m_shouldReveal;
    private Image m_image;

    private static readonly int Cutoff = Shader.PropertyToID("_Cutoff");
    private static readonly int Smoothing = Shader.PropertyToID("_Smoothing");
    private static readonly int TransitionTex = Shader.PropertyToID("_TransitionTex");

    private void Start()
    {
        m_image = GetComponent<Image>();
        m_shouldReveal = true;
        
        SwitchTransition();
    }

    private void Update()
    {
        if (m_shouldReveal)
        {
            m_image.material.SetFloat(Cutoff, Mathf.MoveTowards(m_image.material.GetFloat(Cutoff), 1.1f, m_transitionSpeed * Time.deltaTime));
        }
        else
        {
            m_image.material.SetFloat(Cutoff, Mathf.MoveTowards(m_image.material.GetFloat(Cutoff), -0.1f - m_image.material.GetFloat(Smoothing), m_transitionSpeed * Time.deltaTime));

            if (Math.Abs(m_image.material.GetFloat(Cutoff) - (-0.1f - m_image.material.GetFloat(Smoothing))) < Mathf.Epsilon)
            {
                SceneManager.LoadScene(m_sceneToLoad);
            }
        }
    }

    private void SwitchTransition()
    {
        int newTransition = Random.Range(0, m_transitions.Length);
        m_image.material.SetTexture(TransitionTex, m_transitions[newTransition].texture);
    }

    public void Transition()
    {
        m_shouldReveal = !m_shouldReveal;
        SwitchTransition();
    }
}
