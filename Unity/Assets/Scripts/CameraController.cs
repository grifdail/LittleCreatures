using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float m_LerpSpeed;
    [SerializeField]
    private Transform[] m_Targets;
    [SerializeField, Range(0f, 1.000f)]
    private float m_DeadZone;

    private Vector3 m_StartPosition;

    protected void Start()
    {
        m_StartPosition = transform.position;
        transform.DetachChildren();
    }

    protected void Update()
    {
        Vector3 currentInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        if (currentInput.y > m_DeadZone)
        {
            transform.position = Vector3.Lerp(transform.position, m_Targets[0].position, m_LerpSpeed * Time.deltaTime);
        }

        if (currentInput.y < -m_DeadZone)
        {
            transform.position = Vector3.Lerp(transform.position, m_Targets[2].position, m_LerpSpeed * Time.deltaTime);
        }

        if (currentInput.x > m_DeadZone)
        {
            transform.position = Vector3.Lerp(transform.position, m_Targets[1].position, m_LerpSpeed * Time.deltaTime);
        }

        if (currentInput.x < -m_DeadZone)
        {
            transform.position = Vector3.Lerp(transform.position, m_Targets[3].position, m_LerpSpeed * Time.deltaTime);
        }

        if (currentInput == Vector3.zero)
        {
            transform.position = Vector3.Lerp(transform.position, m_StartPosition, m_LerpSpeed * Time.deltaTime);
        }

        transform.LookAt(Vector3.zero);
    }

    protected void OnDrawGizmos()
    {
        foreach (Transform t in m_Targets)
        {
            Gizmos.DrawLine(transform.position, t.position);
        }     
    }
}