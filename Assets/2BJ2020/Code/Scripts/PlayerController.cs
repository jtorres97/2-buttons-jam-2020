using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public bool IsAlive { get; set; }

    [SerializeField] private Rigidbody2D m_rigidbody2D;
    [SerializeField] private Animator m_animator;
    [SerializeField] private float m_forwardSpeed = 4f;
    [SerializeField] private float m_bounceSpeed = 4f;
    [SerializeField] private GameObject m_giftLaunchPosition;
    [SerializeField] private Laser m_laser;

    private bool m_didJumpAccelerate;
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        IsAlive = true;

        SetCameraX();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Mouse0))
        {
            m_didJumpAccelerate = true;
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Fire()
    {
        var go = ObjectPooler.Instance.GetPooledObject();
        if (go == null) return;

        go.transform.position = m_giftLaunchPosition.transform.position;
        go.transform.rotation = m_giftLaunchPosition.transform.rotation;
        go.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (IsAlive)
        {
            var temp = transform.position;
            temp.x += m_forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if (m_didJumpAccelerate)
            {
                m_didJumpAccelerate = false;
                m_rigidbody2D.velocity = new Vector2(0, m_bounceSpeed);
            }
        }
    }

    public void SetCameraX()
    {
        CameraFollow2D.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ChimneyHolder"))
        {
            if (IsAlive)
            {
                IsAlive = false;
                m_animator.SetBool(IsDead, true);
                m_laser.DisableLaser();
            }
        }
    }

    public void DestroyPlayer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        //gameObject.SetActive(false);
    }
}