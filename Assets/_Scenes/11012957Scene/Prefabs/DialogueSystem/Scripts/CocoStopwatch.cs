using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CocoStopwatch : MonoBehaviour
{
    [SerializeField] bool isStopwatchActive;

    [SerializeField] private TextMeshProUGUI currentTimeText;

    [HideInInspector] public float currentTime;

    void start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if (isStopwatchActive)
        {
            currentTime = currentTime +  Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = "Entscheidung " + time.ToString(@"mm\:ss\:fff");
    }

    public void StartStopWatch()
    {
        isStopwatchActive = true;
    }

    public void StopStopWatch()
    {
        currentTime = 0;
        isStopwatchActive = false;
    }
}
