using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private Vector2 m_startDirection;
    [SerializeField] private bool m_shouldChangeDirection;
    [SerializeField] private float m_changeDirectionXPoint;
    [SerializeField] private Vector2 m_changedDirection;
    [SerializeField] private GameObject m_shotToFire;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private float m_initialTimeBetweenShots;
    [SerializeField] private bool m_canShoot;

    private bool m_allowShooting;
    private float m_shotCounter;

    private void Start()
    {
        m_shotCounter = m_initialTimeBetweenShots;
    }

    private void Update()
    {
        if (!m_shouldChangeDirection)
        {
            transform.position += new Vector3(m_startDirection.x * m_moveSpeed * Time.deltaTime, m_startDirection.y * m_moveSpeed * Time.deltaTime, 0f);
        }
        else
        {
            if (transform.position.x > PlayerController.Instance.transform.position.x + m_changeDirectionXPoint)
            {
                transform.position += new Vector3(m_startDirection.x * m_moveSpeed * Time.deltaTime, m_startDirection.y * m_moveSpeed * Time.deltaTime, 0f);
            }
            else
            {
                transform.position += new Vector3(m_changedDirection.x * m_moveSpeed * Time.deltaTime, m_changedDirection.y * m_moveSpeed * Time.deltaTime, 0f);
            }
        }

        if (m_allowShooting)
        {
            m_shotCounter -= Time.deltaTime;
            if (m_shotCounter <= 0)
            {
                m_shotCounter = Random.Range(m_initialTimeBetweenShots, 1);
                Instantiate(m_shotToFire, m_firePoint.position, m_firePoint.rotation);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        if (m_canShoot)
        {
            m_allowShooting = true;
        }
    }
}
