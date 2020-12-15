using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float m_projectileSpeed;
    
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
            ScoreManager.Instance.AddScore(10);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (ScoreManager.Instance.Score != 0)
            {
                ScoreManager.Instance.RemoveScore(10);
            }
        }
    }
}
