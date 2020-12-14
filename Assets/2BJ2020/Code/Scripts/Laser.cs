using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private LineRenderer m_lineRenderer;
    [SerializeField] private Transform m_firePoint;

    private void Start()
    {
        DisableLaser();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            EnableLaser();
        }

        if (Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
    }

    private void DisableLaser()
    {
        m_lineRenderer.enabled = false;
    }

    private void UpdateLaser()
    {
        var mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        m_lineRenderer.SetPosition(0, m_firePoint.position);
        m_lineRenderer.SetPosition(1, m_firePoint.position + new Vector3(4, 0, 0));
    }

    private void EnableLaser()
    {
        m_lineRenderer.enabled = true;
    }
}
