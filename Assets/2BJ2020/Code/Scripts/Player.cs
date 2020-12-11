using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    public bool IsAlive { get; set; }

    [SerializeField] private Rigidbody2D m_rigidbody2D;
    [SerializeField] private Animator m_animator;
    [SerializeField] private float m_forwardSpeed = 4f;
    [SerializeField] private float m_bounceSpeed = 4f;

    private bool m_didFlap;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        IsAlive = true;
        
        SetCameraX();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_didFlap = true;
        }
    }

    private void FixedUpdate()
    {
        if (IsAlive)
        {
            var temp = transform.position;
            temp.x += m_forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if (m_didFlap)
            {
                m_didFlap = false;
                m_rigidbody2D.velocity = new Vector2(0, m_bounceSpeed);
                
            }
        }
    }

    public void SetCameraX()
    {
        CameraFollow2D.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
        Debug.Log(CameraFollow2D.offsetX);
    }
}
