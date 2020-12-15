using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    
    [SerializeField] private WaveObject[] m_waves;
    [SerializeField] private int m_currentWave;
    [SerializeField] private float m_timeToNextWave;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Random r = new Random();
        m_waves = m_waves.OrderBy(x => r.Next()).ToArray();
        m_timeToNextWave = m_waves[0].timeToSpawn;
    }

    private void Update()
    {
        m_timeToNextWave -= Time.deltaTime;
        if (m_timeToNextWave <= 0)
        {
            Instantiate(m_waves[m_currentWave].theWave, transform.position, transform.rotation);
            if (m_currentWave < m_waves.Length - 1)
            {
                m_currentWave++;
                m_timeToNextWave = m_waves[m_currentWave].timeToSpawn;
            }
            else
            {
                m_currentWave = 0;
                Random r = new Random();
                m_waves = m_waves.OrderBy(x => r.Next()).ToArray();
                m_timeToNextWave = m_waves[m_currentWave].timeToSpawn;
            }
        }
    }
}

[System.Serializable]
public class WaveObject
{
    public float timeToSpawn;
    public EnemyWave theWave;
    
}
