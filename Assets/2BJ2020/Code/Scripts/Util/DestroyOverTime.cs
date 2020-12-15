using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float m_lifetime;

    private void Update()
    {
        Destroy(gameObject, m_lifetime);
    }
}