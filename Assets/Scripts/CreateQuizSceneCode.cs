using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class CreateQuizSceneCode : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject questionPanel;
    [SerializeField] private TMP_InputField nameQuiz;
    [SerializeField] private TMP_InputField secriptionQuiz;

    [SerializeField] private Button nextButton;
    [SerializeField] private Button nextQustionButton;
    [SerializeField] private Button saveButton;

    [SerializeField] private TMP_Text numberQustion;

    [SerializeField] private GameObject exitPanel;

    int numberOfQustion = 0;

    [SerializeField] private TMP_InputField qustionInput;
    [SerializeField] private TMP_InputField themeInput;
    [SerializeField] private TMP_InputField rightInput;
    [SerializeField] private TMP_InputField wrong1Input;
    [SerializeField] private TMP_InputField wrong2Input;
    [SerializeField] private TMP_InputField wrong3Input;
    [SerializeField] private TMP_InputField priceInput;


    public List<string> Qustion = new List<string>();
    public List<string> theme = new List<string>();
    public List<string> rightAnswer = new List<string>();
    public List<string> wrongAnswer1 = new List<string>();
    public List<string> wrongAnswer2 = new List<string>();
    public List<string> wrongAnswer3 = new List<string>();
    public List<string> price = new List<string>();

    string idQuiz;

    public void SaveQustionButton()
    {
        Qustion.Add(qustionInput.text);
        theme.Add(themeInput.text);
        rightAnswer.Add(rightInput.text);
        wrongAnswer1.Add(wrong2Input.text);
        wrongAnswer2.Add(wrong2Input.text);
        wrongAnswer3.Add(wrong2Input.text);
        price.Add(priceInput.text);

        numberOfQustion++;

        numberQustion.text = Convert.ToString(numberOfQustion);

        if (numberOfQustion >= 4)
        {
            saveButton.interactable = true;
        }
        else
        {
            saveButton.interactable = false;
        }
    }

    public void SaveButtonClick()
    {
        StartCoroutine(InsertMainInfoBD());
        //StartCoroutine(InsertDataQustion());
        //StartCoroutine(InsertQustions());
        numberOfQustion = 0;
    }



    IEnumerator InsertDataQustion()
    {
        WWWForm wwwFrom = new WWWForm();
        wwwFrom.AddField("QuizName", DBManager.QuizID);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", wwwFrom);
        idQuiz = www.text;
        yield return www;


    }

    IEnumerator InsertQustions()
    {
        int i = 0;
        while (i < Qustion.Count)
        {
            WWWForm wwwForm1 = new WWWForm();
            wwwForm1.AddField("QuizID", idQuiz);
            wwwForm1.AddField("QuizQustion", Qustion[i]);
            wwwForm1.AddField("QuizTheme", theme[i]);
            wwwForm1.AddField("QuizRightAnswer", rightAnswer[i]);
            wwwForm1.AddField("QuizWrongAnswer1", wrongAnswer1[i]);
            wwwForm1.AddField("QuizWrongAnswer2", wrongAnswer2[i]);
            wwwForm1.AddField("QuizWrongAnswer3", wrongAnswer3[i]);
            wwwForm1.AddField("QuizPrice", wrongAnswer3[i]);
            WWW www = new WWW("http://localhost/sqlconnect/SaveQuiz.php", wwwForm1);
            yield return www;
        }
    }


    public void VerifyButtonNextQustion()
    {
        nextQustionButton.interactable = (qustionInput.text.Length >= 4 && themeInput.text.Length >= 4 && rightInput.text.Length >= 1 && wrong1Input.text.Length >= 1 && wrong2Input.text.Length >= 1 && wrong3Input.text.Length >= 1);
    }


    public void ButtonExitClick()
    {
        exitPanel.SetActive(true);
    }

    public void ButtonNoClick()
    {
        exitPanel.SetActive(false);
    }
    public void ButtonYesClick()
    {
        infoPanel.SetActive(true);
        questionPanel.SetActive(false);
        SceneManager.LoadScene(3);
    }

    public void nextButtonClick()
    {
        infoPanel.SetActive(false);
        questionPanel.SetActive(true);
    }

    IEnumerator InsertMainInfoBD()
    {
        WWWForm wwwForm1 = new WWWForm();
        wwwForm1.AddField("NameQuiz", nameQuiz.text);
        wwwForm1.AddField("DescriptionQuiz", secriptionQuiz.text);
        WWW www = new WWW("http://localhost/sqlconnect/SaveMainQuiz.php", wwwForm1);
        return www;
    }

    public void VerifyButtonNext()
    {
        nextButton.interactable = (nameQuiz.text.Length >= 4 && secriptionQuiz.text.Length >= 4);
    }
}
