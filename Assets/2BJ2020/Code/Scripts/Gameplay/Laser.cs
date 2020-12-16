using TMPro;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer m_lineRenderer;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private bool m_isPlayer;
    [SerializeField] private GameObject m_objectExplosion;
    [SerializeField] private GameObject m_floatingScoreTextPrefab;

    private void Start()
    {
        EnableLaser();
    }

    private void Update()
    {
        UpdateLaser();
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
                Instantiate(m_objectExplosion, hit.collider.transform.position, hit.collider.transform.rotation);
                Destroy(hit.collider.gameObject);
                
                ScoreManager.Instance.AddScore(10);

                GameObject scoreTextUi = Instantiate(m_floatingScoreTextPrefab, hit.collider.transform.position, hit.collider.transform.rotation);
                scoreTextUi.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("+10");

                SoundController.Instance.PlaySFX(1, true);
            }

            if (m_isPlayer && hit.collider.CompareTag("Boss"))
            {
                Instantiate(m_objectExplosion, hit.collider.transform.position, hit.collider.transform.rotation);
                Destroy(hit.collider.gameObject);
                
                ScoreManager.Instance.AddScore(1000);

                GameObject scoreTextUi = Instantiate(m_floatingScoreTextPrefab, hit.collider.transform.position, hit.collider.transform.rotation);
                scoreTextUi.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("+1000");

                SoundController.Instance.PlaySFX(1, true);
            }
        }
    }

    public void EnableLaser()
    {
        m_lineRenderer.enabled = true;
    }
}
