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
        // Play little sparkle animation
        m_animator.SetBool(DroppedIntoChimney, true);
        
        // Make it stay still
        m_rigidbody2D.velocity = Vector2.zero;
        m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        
        // TODO: Add score here
    }
}
