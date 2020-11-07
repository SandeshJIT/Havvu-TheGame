using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    public float currenttime = 0f;
    public float starttime = 100f;
    public Text CountDownText;
    void Start()
    {
        currenttime = starttime;
    }
    void Update()
    {
        currenttime -= 1*Time.deltaTime;
        CountDownText.text = currenttime.ToString("0");
        

    }
}
