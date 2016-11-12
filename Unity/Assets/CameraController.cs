using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Distance"), SerializeField]
    private float m_Height;
    [SerializeField]
    private float m_MinimumDistanceToCreature;
    [SerializeField]
    private float m_MaximumDistanceToCreature;
    [SerializeField, Range(0f, 0.100f)]
    private float m_LerpSpeed;

    [Header("Angle"), SerializeField]
    private float m_Angle;
    [SerializeField, Range(0f, 0.100f)]
    private float m_AngleSpeed;

    private float m_DistanceFromCreature = 20f;
    private float m_FormerDistanceFromCreature;

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector3 currentInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (currentInput.x > 0)
        {
            m_Angle += m_AngleSpeed;
        }
        else if (currentInput.x < 0)
        {
            m_Angle -= m_AngleSpeed;
        }

        if (currentInput.z > 0)
        {
            m_DistanceFromCreature += m_LerpSpeed;
        }
        else if (currentInput.z < 0)
        {
            m_DistanceFromCreature -= m_LerpSpeed;
        }

        float x = m_DistanceFromCreature * Mathf.Sin(m_Angle);
        float z = m_DistanceFromCreature * Mathf.Cos(m_Angle);

        transform.position = Vector3.Lerp(transform.position, new Vector3(x, m_Height, z), m_LerpSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}