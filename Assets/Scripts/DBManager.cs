using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager 
{
    public static string username;
    public static int QuizID = 1;


    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }
}
