using System;
using TMPro;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float m_projectileSpeed;
    [SerializeField] private GameObject m_floatingScoreTextPrefab;

    private Rigidbody2D m_rigidbody2D;
    private Animator m_animator;
    
    private static readonly int DroppedIntoChimney = Animator.StringToHash("DroppedIntoChimney");

    private void OnEnable()
    {
        if (m_rigidbody2D != null)
        {
            m_rigidbody2D.constraints = RigidbodyConstraints2D.None;
            m_rigidbody2D.velocity = new Vector2(1, -1) * m_projectileSpeed;
        }
        Invoke(nameof(Disable), 2f);
    }

    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_rigidbody2D.velocity = new Vector2(1, -1) * m_projectileSpeed;
        m_animator = GetComponent<Animator>();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GiftCatcher"))
        {
            m_animator.SetBool(DroppedIntoChimney, true);
            m_rigidbody2D.velocity = Vector2.zero;
            m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            ScoreManager.Instance.AddScore(100);
            
            GameObject scoreTextUi = Instantiate(m_floatingScoreTextPrefab, m_rigidbody2D.transform.position, m_rigidbody2D.transform.rotation);
            scoreTextUi.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("+100");

            SoundController.Instance.PlaySFX(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (ScoreManager.Instance.Score != 0)
            {
                GameObject scoreTextUi = Instantiate(m_floatingScoreTextPrefab, m_rigidbody2D.transform.position + new Vector3(0, 7f), m_rigidbody2D.transform.rotation);
                scoreTextUi.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("-100");
                scoreTextUi.transform.GetChild(0).GetComponent<TextMeshPro>().color = new Color(255, 0, 0);
                
                ScoreManager.Instance.RemoveScore(100);
                
                SoundController.Instance.PlaySFX(3);
            }
        }
    }
}
