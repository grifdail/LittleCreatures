using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Interview : MonoBehaviour
{
    [Header("Creature"), SerializeField]
    private PuppetController m_PuppetController;
    [SerializeField]
    private Transform m_BodyTransform;
    private List<Transform> m_BodyParts = new List<Transform>();

    [Header("Questions"), SerializeField]
    private Questions[] m_Questions;
    [SerializeField]
    private Image[] m_CurrentQuestionsImages;

    [Header("Answers"), SerializeField]
    private float m_ValidationTime = 0f;
    [SerializeField]
    private Answers[] m_Answers;

    private int m_QuestionIndex = 0; // Question being asked
    private int m_QuestionAsked = 0; // Amount of questions that have been asked
    private List<int> m_UnaskedQuestions = new List<int>(); // List of unasked questions

    private float m_ValidationTimer; 
    private int m_AnswerIndex = 0; // the direction the player validated his choice in

    protected void Start()
    {
        InitialiseBodyParts();
        InitialiseUnaskedQuestions();
        AskNewQuestion();
    }

    private void InitialiseUnaskedQuestions()
    {
        for (int i = 0; i < m_Questions.Length; i++)
        {
            m_UnaskedQuestions.Add(i);
        }
    }

    private void InitialiseBodyParts()
    {
        // Instantiate body

        // Add body parts
        for (int i = 0; i < 5; i++)
        {
            m_BodyParts.Add(m_BodyTransform.GetChild(i).GetComponent<Transform>());
        }
    }

    protected void Update()
    {
        SelectAnswer();
    }

    private void AskNewQuestion()
    {
        AttributeQuestionIndex();
        UpdateQuestion();
    }

    // Attribute a never asked question
    private void AttributeQuestionIndex()
    {
        int newIndex = Random.Range(0, m_UnaskedQuestions.Count);
        m_QuestionIndex = newIndex;
        m_UnaskedQuestions.RemoveAt(newIndex);
    }

    private void UpdateQuestion()
    {
        for (int i = 0; i < m_CurrentQuestionsImages.Length; i++)
        {
            m_CurrentQuestionsImages[i].sprite = m_Questions[m_QuestionAsked].m_QuestionsImages[i].sprite;
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
        // Down is random choice
        if (m_AnswerIndex == 3)
        {
            int randomBodyPart = Random.Range(0, 3);
            m_BodyParts[m_QuestionAsked].GetComponent<MeshFilter>().sharedMesh = m_Answers[m_QuestionIndex].m_AnswersMeshes[randomBodyPart].GetComponent<MeshFilter>().sharedMesh;
            m_BodyParts[m_QuestionAsked].GetComponent<MeshRenderer>().sharedMaterial = m_Answers[m_QuestionIndex].m_AnswersMeshes[randomBodyPart].GetComponent<MeshRenderer>().sharedMaterial;
            //m_BodyParts[m_QuestionAsked].GetComponent<MeshFilter>().sharedMesh = m_Questions[m_QuestionIndex].m_AnswersMeshes[randomBodyPart].GetComponent<MeshFilter>().sharedMesh;
            //m_BodyParts[m_QuestionAsked].GetComponent<MeshRenderer>().sharedMaterial = m_Questions[m_QuestionIndex].m_AnswersMeshes[randomBodyPart].GetComponent<MeshRenderer>().sharedMaterial;
        }
        else
        {
            m_BodyParts[m_QuestionAsked].GetComponent<MeshFilter>().sharedMesh = m_Answers[m_QuestionIndex].m_AnswersMeshes[m_AnswerIndex].GetComponent<MeshFilter>().sharedMesh;
            m_BodyParts[m_QuestionAsked].GetComponent<MeshRenderer>().sharedMaterial = m_Answers[m_QuestionIndex].m_AnswersMeshes[m_AnswerIndex].GetComponent<MeshRenderer>().sharedMaterial;
            //m_BodyParts[m_QuestionAsked].GetComponent<MeshFilter>().sharedMesh = m_Questions[m_QuestionIndex].m_AnswersMeshes[m_AnswerIndex].GetComponent<MeshFilter>().sharedMesh;
            //m_BodyParts[m_QuestionAsked].GetComponent<MeshRenderer>().sharedMaterial = m_Questions[m_QuestionIndex].m_AnswersMeshes[m_AnswerIndex].GetComponent<MeshRenderer>().sharedMaterial;
        }

        EndQuestion();
    }

    private void EndQuestion()
    {
        m_QuestionAsked++;

        if (m_UnaskedQuestions.Count > 0)
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
        m_PuppetController.enabled = true;
        gameObject.SetActive(false);
    }
}

[System.Serializable]
public class Questions
{
    public string m_Question;
    public Image[] m_QuestionsImages;
    //public Transform[] m_AnswersMeshes;
}

[System.Serializable]
public class Answers
{
    public string m_Answer;
    public Transform[] m_AnswersMeshes;
}