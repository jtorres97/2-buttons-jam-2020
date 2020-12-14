using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [SerializeField] private GameObject m_pooledObject;
    [SerializeField] private int m_pooledAmount;
    [SerializeField] private bool m_willGrow;

    private List<GameObject> m_pooledObjects;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_pooledObjects = new List<GameObject>();
        for (int i = 0; i < m_pooledAmount; i++)
        {
            var go = Instantiate(m_pooledObject);
            go.SetActive(false);
            m_pooledObjects.Add(go);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in m_pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        if (m_willGrow)
        {
            var go = Instantiate(m_pooledObject);
            m_pooledObjects.Add(go);
            return go;
        }
        
        return null;
    }
}
