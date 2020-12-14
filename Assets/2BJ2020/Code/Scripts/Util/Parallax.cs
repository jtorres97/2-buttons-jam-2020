using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject m_camera;
    [SerializeField] private float m_parallaxEffect;
    
    private float m_length, m_startPos;

    private void Start()
    {
        m_startPos = transform.position.x;
        m_length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (m_camera.transform.position.x * (1 - m_parallaxEffect));
        float dist = (m_camera.transform.position.x * m_parallaxEffect);
        
        transform.position = new Vector3(m_startPos + dist, transform.position.y, transform.position.z);

        if (temp > m_startPos + m_length)
        {
            m_startPos += m_length;
        }
        else if (temp < m_startPos - m_length)
        {
            m_startPos -= m_length;
        }
    }
}
