using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private LineRenderer m_lineRenderer;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private bool m_isPlayer;
    [SerializeField] private bool m_isEnemy;

    private void Start()
    {
        EnableLaser();
    }

    private void Update()
    {
        UpdateLaser();
        
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     EnableLaser();
        // }
        //
        // if (Input.GetButton("Fire1"))
        // {
        //     UpdateLaser();
        // }
        //
        // if (Input.GetButtonUp("Fire1"))
        // {
        //     DisableLaser();
        // }
    }

    public void DisableLaser()
    {
        m_lineRenderer.enabled = false;
    }

    public void UpdateLaser()
    {
        m_lineRenderer.SetPosition(0, m_firePoint.position);
        m_lineRenderer.SetPosition(1, m_firePoint.position + new Vector3(5, 0, 0));

        Vector2 direction = (m_firePoint.position + new Vector3(5, 0, 0)) - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude);

        if (hit)
        {
            m_lineRenderer.SetPosition(1, hit.point);
            if (m_isPlayer && hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit the enemy");
                Destroy(hit.collider.gameObject);
            }
        }
    }

    public void EnableLaser()
    {
        m_lineRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Laser Collision");
    }
}
