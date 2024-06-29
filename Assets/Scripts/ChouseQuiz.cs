using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChouseQuiz : MonoBehaviour
{
    [SerializeField] private TMP_InputField quizIDInput;
    [SerializeField] private TMP_Text errorText;

    [SerializeField] Button submitButtonID;

    private int quizIdValue;

    public void ChouseButtoClick()
    {
        StartCoroutine(CheckIsIDQuizRight());
    }

    IEnumerator CheckIsIDQuizRight()
    {
        WWWForm wwwFrom = new WWWForm();
        wwwFrom.AddField("QuizID", quizIDInput.text);

        WWW www = new WWW("http://localhost/sqlconnect/isIDCorrect.php", wwwFrom);
        yield return www;

        if (www.text[0] == '0')
        {
            if (int.TryParse(quizIDInput.text, out quizIdValue))
            {
                DBManager.QuizID = quizIdValue;
                UnityEngine.SceneManagement.SceneManager.LoadScene(6);
            }
            else
            {
                errorText.text = "Неверный формат ID викторины";
            }
        }
        else
        {
            Debug.Log("Создание пользователя преравно. Ошибка #" + www.text);
            errorText.text = "Создание пользователя преравно. Ошибка #" + www.text;
        }
    }

    public void VerifyInputs()
    {
        submitButtonID.interactable = (quizIDInput.text.Length >= 1);
    }

    public void CreatQuizButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
}
