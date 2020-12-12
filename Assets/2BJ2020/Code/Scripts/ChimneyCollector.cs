using UnityEngine;
using Random = UnityEngine.Random;

public class ChimneyCollector : MonoBehaviour
{
    private GameObject[] m_chimneyHolders;
    private float m_distance = 2.5f;
    private float m_lastChimneysX;
    private float m_chimneyMin = -4.25f;
    private float m_chimneyMax = 0f;

    private void Awake()
    {
        m_chimneyHolders = GameObject.FindGameObjectsWithTag("ChimneyHolder");

        for (int i = 0; i < m_chimneyHolders.Length; i++)
        {
            Vector3 temp = m_chimneyHolders[i].transform.position;
            temp.y = Random.Range(m_chimneyMin, m_chimneyMax);
            m_chimneyHolders[i].transform.position = temp;
        }

        m_lastChimneysX = m_chimneyHolders[0].transform.position.x;
        
        for (int i = 1; i < m_chimneyHolders.Length; i++)
        {
            if (m_lastChimneysX < m_chimneyHolders[i].transform.position.x)
            {
                m_lastChimneysX = m_chimneyHolders[i].transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChimneyHolder"))
        {
            Vector3 temp = other.transform.position;

            temp.x = m_lastChimneysX + m_distance;
            temp.y = Random.Range(m_chimneyMin, m_chimneyMax);

            other.transform.position = temp;

            m_lastChimneysX = temp.x;
        }
    }
}
