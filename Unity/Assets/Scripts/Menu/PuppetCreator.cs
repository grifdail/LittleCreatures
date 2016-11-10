using UnityEngine;

public class PuppetCreator : MonoBehaviour
{
    [SerializeField]
    private PuppetPart[] m_PuppetParts;
    private int m_PuppetPartIndex = 0;
    private int m_PuppetPartVariationIndex = 0;

    protected void Update()
    {
        // Switch mesh variation
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (m_PuppetPartVariationIndex > 0)
            {
                m_PuppetPartVariationIndex--;
            }
            else
            {
                m_PuppetPartVariationIndex = m_PuppetParts[m_PuppetPartIndex].m_Meshes.Length - 1;
            }

            UpdateMesh();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (m_PuppetPartVariationIndex < m_PuppetParts[m_PuppetPartIndex].m_Meshes.Length - 1)
            {
                m_PuppetPartVariationIndex++;
            }
            else
            {
                m_PuppetPartVariationIndex = 0;
            }

            UpdateMesh();
        }

        // Switch to new body part
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_PuppetPartIndex < m_PuppetParts.Length - 1)
            {
                m_PuppetPartIndex++;
            }
            else
            {
                m_PuppetPartIndex = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (m_PuppetPartIndex > 0)
            {
                m_PuppetPartIndex--;
            }
            else
            {
                m_PuppetPartIndex = m_PuppetParts.Length - 1;
            }
        }
    }

    private void UpdateMesh()
    {
        m_PuppetParts[m_PuppetPartIndex].m_BodyPart.mesh = m_PuppetParts[m_PuppetPartIndex].m_Meshes[m_PuppetPartVariationIndex].mesh;
    }
}

[System.Serializable]
public class PuppetPart
{
    public MeshFilter m_BodyPart;
    public MeshFilter[] m_Meshes;
}