using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{ 
    private static float timer;

    [SerializeField] private TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        timer = GameController.Instance.GetTimer();
        UpdateTimerDisplay(timer);
    }

    private void UpdateTimerDisplay(float time)
    {
        double displayTime = Math.Round(time, 2);
        timerText.text = displayTime.ToString();
    }
}
