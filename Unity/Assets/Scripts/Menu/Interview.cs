using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Interview : MonoBehaviour
{    
    [SerializeField]
    private Image[] m_DisplayedAnswers;
    [SerializeField]
    private Questions[] m_Questions;

    private int m_NumberOfQuestions;

    private int m_QuestionIndex;
    private List<int> m_UnaskedQuestions = new List<int>();

    [SerializeField]
    private float m_ValidationTime;
    private float m_ValidationTimer;
    private int m_AnswerIndex = 0;

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

    private void AttributeBody()
    {
        
    }

    private void AskNewQuestion()
    {
        AttributeQuestionIndex();
        UpdateQuestion();
    }

    private void AttributeQuestionIndex()
    {
        int newIndex = Random.Range(0, m_UnaskedQuestions.Count);
        m_QuestionIndex = newIndex;
        m_UnaskedQuestions.RemoveAt(newIndex); 
    }

    private void UpdateQuestion()
    {
        for (int i = 0; i < m_DisplayedAnswers.Length; i++)
        {
            m_DisplayedAnswers[i].sprite = m_Questions[0].m_AnswersImages[i].sprite;
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
                print("DOWN");
                m_AnswerIndex = 3;
            }
        }
    }
}

[System.Serializable]
public class Questions
{
    public string m_Question;
    public Image[] m_AnswersImages;
    public MeshRenderer[] m_AnswersMeshes;
}