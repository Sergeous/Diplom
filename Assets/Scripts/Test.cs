using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject test;


    void Start()
    {


        Instantiate(test);

        Debug.Log("Allright");
    }


}
