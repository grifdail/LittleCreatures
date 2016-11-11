using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Interview : MonoBehaviour
{
    [Header("Creature"), SerializeField]
    private PuppetController m_PuppetController;
    [SerializeField]
    private MeshFilter[] m_BodyParts;

    [Header("Questions && Answers"), SerializeField]
    private float m_ValidationTime;
    [SerializeField]
    private Image[] m_ImagesOfAnswers;
    [SerializeField]
    private Questions[] m_Questions;

    private int m_QuestionIndex = 0; // Question being asked
    private int m_QuestionAsked = 0; // Amount of questions that have been asked
    private List<int> m_UnaskedQuestions = new List<int>(); // List of unasked questions

    private float m_ValidationTimer; 
    private int m_AnswerIndex = 0; // the direction the player validated his choice in

    Vector2 currentInput;

    protected void Start()
    {
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
        for (int i = 0; i < m_ImagesOfAnswers.Length; i++)
        {
            m_ImagesOfAnswers[i].sprite = m_Questions[m_QuestionAsked].m_AnswersImages[i].sprite;
        }
    }

    private void SelectAnswer()
    {
        currentInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

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
                print("RIGHT");
                m_AnswerIndex = 2;
            }
            else
            {
                print("LEFT");
                m_AnswerIndex = 1;
            }
        }
        // Vertical axis
        else
        {
            if (y > 0)
            {
                print("UP");
                m_AnswerIndex = 0;
            }
            else
            {
                // Random choice
                print("DOWN");
                m_AnswerIndex = 3;
            }
        }

        UpdateMesh();
    }

    private void UpdateMesh()
    {
        if (m_AnswerIndex == 3)
        {
            int randomBodyPart = Random.Range(0, 3);
            m_BodyParts[m_QuestionAsked].sharedMesh = m_Questions[m_QuestionIndex].m_AnswersMeshes[randomBodyPart].sharedMesh;
        }
        else
        {
            m_BodyParts[m_QuestionAsked].sharedMesh = m_Questions[m_QuestionIndex].m_AnswersMeshes[m_AnswerIndex].sharedMesh;
        }

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
        enabled = false;
    }
}

[System.Serializable]
public class Questions
{
    public string m_Question;
    public Image[] m_AnswersImages;
    public MeshFilter[] m_AnswersMeshes;
}