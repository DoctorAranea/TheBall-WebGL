using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    
    public int seconds;
    public bool timerIsActive;

    private Text textTimer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        textTimer = GetComponent<Text>();
        StartCoroutine(TimerTick());
    }

    private IEnumerator TimerTick()
    {
        while (timerIsActive)
        {
            yield return new WaitForSecondsRealtime(1);
            seconds++;
            textTimer.text = seconds.ToString();
        }
    }

    public void SaveTime()
    {
        PlayerPrefs.SetInt("Seconds", seconds);
        Debug.Log($"Time {seconds} saved");
        timerIsActive = false;
    }
}
