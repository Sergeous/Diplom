using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSceneWork : MonoBehaviour
{
    DBManager DBManager = new DBManager();

    string text;
    string nameQuiz;
    string descriptionQuiz;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    int i = -1;
    public List<string> Qustion = new List<string>();
    public List<string> rightAnswer = new List<string>();
    public List<string> wrongAnswer1 = new List<string>();
    public List<string> wrongAnswer2 = new List<string>();
    public List<string> wrongAnswer3 = new List<string>();
    public TMP_Text MainText;
    public Text datatext;

    public void Start()
    {
        StartCoroutine(LoginPlayer());
        Debug.Log(datatext);
    }

    public void exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    IEnumerator LoginPlayer()
    {
        WWWForm wwwFrom = new WWWForm();
        wwwFrom.AddField("QuizID", DBManager.QuizID);
        WWW www = new WWW("http://localhost/sqlconnect/test.php", wwwFrom);
        yield return www;

        Debug.Log(www.text);
    }




    public void button1Click()
    {
        if(button1.GetComponentInChildren<Text>().text == rightAnswer[i])
        {

        }
        else
        {

        }
    }

    public void button2Click()
    {
        if (button2.GetComponentInChildren<Text>().text == rightAnswer[i])
        {

        }
        else
        {
            nextQustion();
        }
    }

    public void button3Click()
    {
        if (button3.GetComponentInChildren<Text>().text == rightAnswer[i])
        {

        }
        else
        {
            nextQustion();
        }
    }


    public void button4Click()
    {
        if (button4.GetComponentInChildren<Text>().text == rightAnswer[i])
        {

        }
        else
        {
            nextQustion();
        }
    }

    public void nextQustion()
    {
        i++;
        if (i >= rightAnswer.Count - 1)
        {
            MainText.text = "Вы победили!";
            button1.GetComponentInChildren<Text>().text = "";
            button2.GetComponentInChildren<Text>().text = "";
            button3.GetComponentInChildren<Text>().text = "";
            button4.GetComponentInChildren<Text>().text = "";
        }
        else
        {
            MainText.text = Qustion[i];
            if (Random.Range(1, 5) == 2)
            {
                button1.GetComponentInChildren<Text>().text = rightAnswer[i];
                button2.GetComponentInChildren<Text>().text = wrongAnswer1[i];
                button3.GetComponentInChildren<Text>().text = wrongAnswer2[i];
                button4.GetComponentInChildren<Text>().text = wrongAnswer3[i];
            }
            else if (Random.Range(4, 10) == 6)
            {
                button1.GetComponentInChildren<Text>().text = wrongAnswer1[i];
                button2.GetComponentInChildren<Text>().text = rightAnswer[i];
                button3.GetComponentInChildren<Text>().text = wrongAnswer2[i];
                button4.GetComponentInChildren<Text>().text = wrongAnswer3[i];
            }
            else if (Random.Range(7, 13) == 10)
            {
                button1.GetComponentInChildren<Text>().text = wrongAnswer1[i];
                button2.GetComponentInChildren<Text>().text = wrongAnswer2[i];
                button3.GetComponentInChildren<Text>().text = rightAnswer[i];
                button4.GetComponentInChildren<Text>().text = wrongAnswer3[i];
            }
            else
            {
                button1.GetComponentInChildren<Text>().text = wrongAnswer1[i];
                button2.GetComponentInChildren<Text>().text = wrongAnswer2[i];
                button3.GetComponentInChildren<Text>().text = wrongAnswer3[i];
                button4.GetComponentInChildren<Text>().text = rightAnswer[i];
            }
        }
    }


}