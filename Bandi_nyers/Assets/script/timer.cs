using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class timerű : MonoBehaviour
{
    public static Stopwatch timer = new Stopwatch();
    private DateTime time = DateTime.Parse("2000.01.01. 00:02");
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        timer.Reset(); 
    }

    // Update is called once per frame
    void Update()
    {
        time -= timer.Elapsed;

    }
}
