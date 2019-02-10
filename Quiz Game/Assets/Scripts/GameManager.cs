using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private string[,] questionDataArray = new string[10, 12];

    private Question currentQuestion;
    private Question tempQuestion;
    [SerializeField]
    private Text questionText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    private Text AnswerAText;

    [SerializeField]
    private Text AnswerBText;

    [SerializeField]
    private Text AnswerCText;

    [SerializeField]
    private Text AnswerDText;

    [SerializeField]
    private Text ButtonAText;

    [SerializeField]
    private Text ButtonBText;

    [SerializeField]
    private Text ButtonCText;

    [SerializeField]
    private Text ButtonDText;

    [SerializeField]
    private Animator animator;


    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            FillQuestionDataArray();
            FillQuestionArray();
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        
    }//end of start

    private void FillQuestionDataArray()
    {
        int counter = 0;
        string line;
 
        System.IO.StreamReader file = new System.IO.StreamReader("Assets//QuestionData.txt");
        while ((line = file.ReadLine()) != null)
        {
            line.ToCharArray();
            string temp = null;
            int count = 3;
            for (int i = 0; i < 10; i++)
            {
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,0] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,1] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,2] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,3] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,4] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,5] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,6] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,7] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,8] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,9] = temp;
                temp = null;
                count++;
                while (line[count] != '\t')
                {
                    temp += line[count];
                }
                questionDataArray[i,10] = temp;
                temp = null;
                count++;
                while (count != line.Length)
                {
                    temp += line[count];
                }
                questionDataArray[i,11] = temp;
            }//end of the while loop
            counter++;
        }//end of for loop
        file.Close();
    }

    void FillQuestionArray()
    {
        for (int i = 0; i < 10; i++)
        {
            int randColumn = Random.Range(0, 5);
            int randRightRow = Random.Range(1, 9);
            int randWrongRowOne = Random.Range(1, 9);
            while (randWrongRowOne == randRightRow)
            {
                randWrongRowOne = Random.Range(1, 9);
            }
            int randWrongRowTwo = Random.Range(1, 9);
            while (randWrongRowTwo == randRightRow || randWrongRowTwo == randWrongRowOne)
            {
                randWrongRowTwo = Random.Range(1, 9);
            }
            int randWrongRowThree = Random.Range(1, 9);
            while (randWrongRowThree == randWrongRowTwo || randWrongRowThree == randWrongRowOne || randWrongRowThree == randRightRow)
            {
                randWrongRowThree = Random.Range(1, 9);
            }

            
            int randCorrectAnswer = Random.Range(1, 4);
            switch(randCorrectAnswer)
            {
                case 1:
                    
                    tempQuestion.prompt = questionDataArray[randColumn + 6,randRightRow].ToString();
                    tempQuestion.rightAnswer = 'A';
                    tempQuestion.AnswerA = questionDataArray[randColumn,randRightRow];
                    tempQuestion.AnswerB = questionDataArray[randColumn,randWrongRowOne];
                    tempQuestion.AnswerC = questionDataArray[randColumn,randWrongRowTwo];
                    tempQuestion.AnswerD = questionDataArray[randColumn,randWrongRowThree];
                    questions[i] = tempQuestion;
                    break;
                case 2:
                    
                    tempQuestion.prompt = questionDataArray[randColumn + 6,randRightRow].ToString();
                    tempQuestion.rightAnswer = 'B';
                    tempQuestion.AnswerA = questionDataArray[randColumn,randWrongRowOne];
                    tempQuestion.AnswerB = questionDataArray[randColumn,randRightRow];
                    tempQuestion.AnswerC = questionDataArray[randColumn,randWrongRowTwo];
                    tempQuestion.AnswerD = questionDataArray[randColumn,randWrongRowThree];
                    questions[i] = tempQuestion;
                    break;
                case 3:
                    
                    tempQuestion.prompt = questionDataArray[randColumn + 6,randRightRow ].ToString();
                    tempQuestion.rightAnswer = 'C';
                    tempQuestion.AnswerA = questionDataArray[randColumn,randWrongRowTwo];
                    tempQuestion.AnswerB = questionDataArray[randColumn,randWrongRowOne];
                    tempQuestion.AnswerC = questionDataArray[randColumn,randRightRow];
                    tempQuestion.AnswerD = questionDataArray[randColumn,randWrongRowThree];
                    questions[i] = tempQuestion;
                    break;
                case 4:
                    
                    tempQuestion.prompt = questionDataArray[randColumn + 6,randRightRow].ToString();
                    tempQuestion.rightAnswer = 'D';
                    tempQuestion.AnswerA = questionDataArray[randColumn,randWrongRowOne];
                    tempQuestion.AnswerB = questionDataArray[randColumn,randWrongRowThree];
                    tempQuestion.AnswerC = questionDataArray[randColumn,randWrongRowTwo];
                    tempQuestion.AnswerD = questionDataArray[randColumn,randRightRow];
                    questions[i] = tempQuestion;
                    break;

            }//end of switch

            questions[i] = tempQuestion;

        }//end of for loop
    }


    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count());
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.prompt;
    
        ButtonAText.text = currentQuestion.AnswerA;
        ButtonBText.text = currentQuestion.AnswerB;
        ButtonCText.text = currentQuestion.AnswerC;
        ButtonDText.text = currentQuestion.AnswerD;

        switch (currentQuestion.rightAnswer)
        {
            case 'A':
                AnswerAText.text = "CORRECT";
                AnswerBText.text = "WRONG";
                AnswerCText.text = "WRONG";
                AnswerDText.text = "WRONG";
                break;
            case 'B':
                AnswerAText.text = "WRONG";
                AnswerBText.text = "CORRECT";
                AnswerCText.text = "WRONG";
                AnswerDText.text = "WRONG";
                break;
            case 'C':
                AnswerAText.text = "WRONG";
                AnswerBText.text = "WRONG";
                AnswerCText.text = "CORRECT";
                AnswerDText.text = "WRONG";
                break;
            case 'D':
                AnswerAText.text = "WRONG";
                AnswerBText.text = "WRONG";
                AnswerCText.text = "WRONG";
                AnswerDText.text = "CORRECT";
                break;
        }//end of switch
    }

    /*public void UserSelectA()
    {
        animator.SetTrigger("A");
        if (currentQuestion.rightAnswer == 'A')
        {
            Debug.Log("Correct");

        }
        else
        {
            Debug.Log("Wrong");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct");

        }
        else
        {
            Debug.Log("Wrong");
        }

        StartCoroutine(TransitionToNextQuestion());
    }*/

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}//end of GameManager
