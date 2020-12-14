using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float m_projectileSpeed;
    
    private Rigidbody2D m_rigidbody2D;

    private void OnEnable()
    {
        if (m_rigidbody2D != null)
        {
            m_rigidbody2D.velocity = new Vector2(1, -1) * m_projectileSpeed;
        }
        Invoke(nameof(Disable), 2f);
    }

    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_rigidbody2D.velocity = new Vector2(1, -1) * m_projectileSpeed;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
