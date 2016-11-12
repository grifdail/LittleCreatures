using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Interview : MonoBehaviour
{
    [Header("Creature"), SerializeField]
    private PuppetController m_PuppetController;
    [SerializeField]
    private Transform m_BodyTransform;

    [Header("Questions"), SerializeField]
    private Questions[] m_Questions;
    
    [SerializeField]
    private Image[] m_CurrentQuestionsImages;

    [Header("Answers"), SerializeField]
    private float m_ValidationTime = 0f;
    [SerializeField]
    private GameObject[] m_Answers;

    private int m_CurrentQuestionIndex = 0;
    private PuppetController.PuppetString m_CurrentPuppetPart;

    private float m_ValidationTimer; 
    private int m_AnswerIndex = 0; // the direction the player validated his choice in



    protected void Start()
    {
        AskNewQuestion();
    }

    protected void Update()
    {
        SelectAnswer();
    }

    private void AskNewQuestion()
    {
        m_CurrentPuppetPart = m_PuppetController.strings[m_CurrentQuestionIndex];
        UpdateQuestion();
    }

    private void UpdateQuestion()
    {
        for (int i = 0; i < m_CurrentQuestionsImages.Length; i++)
        {
            m_CurrentQuestionsImages[i].sprite = m_Questions[m_CurrentQuestionIndex].m_QuestionsImages[i].sprite;
        }
    }

    private void SelectAnswer()
    {
        Vector2 currentInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (currentInput != Vector2.zero)
        {
            m_ValidationTimer += Time.deltaTime;

            if (m_ValidationTimer > m_ValidationTime)
            {
                ValidateAnswer(currentInput.x, currentInput.y);
            }
        }
        else
        {
            m_ValidationTimer = 0;
        }
    }

    private void ValidateAnswer(float x, float y)
    {
        m_ValidationTimer = 0;

        float absoluteX = Mathf.Abs(x);
        float absoluteY = Mathf.Abs(y);

        // Horizontal axis
        if (absoluteX > absoluteY)
        {
            if (x > 0)
            {
                m_AnswerIndex = 2;
            }
            else
            {
                m_AnswerIndex = 1;
            }
        }
        // Vertical axis
        else
        {
            if (y > 0)
            {
                m_AnswerIndex = 0;
            }
            else
            {
                m_AnswerIndex = 3;
            }
        }

        UpdateMesh();
    }

    private void UpdateMesh()
    {
        GameObject mesh = m_Answers[Random.Range(0, m_Answers.Length)];
        GameObject go = Instantiate(mesh, m_BodyTransform.position, Quaternion.Euler(m_CurrentPuppetPart.angle), m_BodyTransform) as GameObject;
        Transform goTransform = go.transform;
        goTransform.position = m_CurrentPuppetPart.membersLocation.position;
        goTransform.GetChild(0).GetComponent<ConfigurableJoint>().connectedBody = m_BodyTransform.GetComponent<Rigidbody>();
        m_CurrentPuppetPart.handle.GetComponent<Joint>().connectedBody = goTransform.GetChild(2).GetComponent<Rigidbody>();

        EndQuestion();
    }

    private void EndQuestion()
    {
        m_CurrentQuestionIndex++;

        if (m_CurrentQuestionIndex < m_PuppetController.strings.Length)
        {
            AskNewQuestion();
        }
        else
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        //  m_PuppetController.enabled = true;
        gameObject.SetActive(false);
    }

    public bool isCompleted()
    {
        return !(m_CurrentQuestionIndex < m_PuppetController.strings.Length);
    }
}

[System.Serializable]
public class Questions
{
    public string m_Question;
    public Image[] m_QuestionsImages;
}
