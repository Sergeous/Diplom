using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public InputField nameInputField;
    public InputField passwordInputField;

    public Button submitButton;

    public TextMeshProUGUI errorText;

    private bool isPasswordSeen = false;
    public void Start()
    {
        passwordInputField.contentType = InputField.ContentType.Password;
    }

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    public void CallExit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    IEnumerator LoginPlayer()
    {
        WWWForm wwwFrom = new WWWForm();
        wwwFrom.AddField("email", nameInputField.text);
        wwwFrom.AddField("password", passwordInputField.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", wwwFrom);
        yield return www;

        if (www.text[0] == '0')
        {
            DBManager.username = nameInputField.text;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Создание пользователя преравно. Ошибка #" + www.text);
            errorText.text = "Создание пользователя преравно. Ошибка #" + www.text;
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameInputField.text.Length >= 8 && passwordInputField.text.Length >= 8);
    }
    public void PasswordView()
    {
        if (isPasswordSeen == false)
        {
            passwordInputField.contentType = InputField.ContentType.Standard;
            isPasswordSeen = true;
        }
        else
        {
            passwordInputField.contentType = InputField.ContentType.Password;
            isPasswordSeen = false;
        }
    }
}
