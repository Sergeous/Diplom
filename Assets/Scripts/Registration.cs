using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameInputField;
    public InputField emailInputField;
    public InputField passwordInputField;

    public TextMeshProUGUI errorText;

    public Button submitButton;

    private bool isPasswordSeen = false;

    public void Start()
    {
        passwordInputField.contentType = InputField.ContentType.Password;
    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    public void CallExit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    IEnumerator Register()
    {
        WWWForm wwwFrom = new WWWForm();
        wwwFrom.AddField("name", nameInputField.text);
        wwwFrom.AddField("email", emailInputField.text);
        wwwFrom.AddField("password", passwordInputField.text);

        WWW www = new WWW("http://localhost/sqlconnect/register.php", wwwFrom);
        yield return www;

        if(www.text == "0")
        {
            Debug.Log("User successfully created");
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
        submitButton.interactable = (nameInputField.text.Length >= 4 && passwordInputField.text.Length >= 8 && emailInputField.text.Length >= 8);


    } 

    public void PasswordView()
    {
        if(isPasswordSeen == false)
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
