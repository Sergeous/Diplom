using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    IEnumerator Start()
    {
        WWW request = new WWW("http://localhost/sqlconnect/webtest.php");
        yield return request;

        Debug.Log(request);

        //string[] webresults = request.text.Split('\t');
        //foreach (string s in webresults)
        //{
        //    Debug.Log(s);
        //}
    }

}
