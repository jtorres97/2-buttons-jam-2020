﻿using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private float m_shotSpeed = 7f;
    
    private void Update()
    {
        transform.position -= new Vector3(m_shotSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController.Instance.DestroyPlayer();
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}