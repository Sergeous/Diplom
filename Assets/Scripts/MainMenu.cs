using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text logInText;
    [SerializeField] private GameObject panelAuthoriz;


    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            logInText.text = "Игрок: " + DBManager.username;
            panelAuthoriz.SetActive(false);
        }
    }

    public void GoToRegistration()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLogIn()
    {
        SceneManager.LoadScene(2);
    }

    public void exit()
    {
        Application.Quit();
    }
    public void GoToGame()
    {
        if (DBManager.LoggedIn)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            logInText.text = "Необходимо сначала зайти или зарегестрироваться";
        }
    }
}
