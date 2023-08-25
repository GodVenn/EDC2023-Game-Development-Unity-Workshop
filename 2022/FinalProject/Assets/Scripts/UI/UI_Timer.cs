using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UI_Timer : MonoBehaviour
{
    public Color StartColor;
    public Color MidColor;
    public Color EndColor;

    private TextMeshProUGUI textElement;
    private float MaxTime;
    private float HalfTime => MaxTime / 2;

    private void OnValidate()
    {
        textElement = GetComponent<TextMeshProUGUI>();
        textElement.color = StartColor;
    }

    private void Start()
    {
        MaxTime = GameManager.instance.TimeLeft;
        if (MaxTime == 0)
            MaxTime = 0.01f;
    }

    private void Update()
    {
        float timeLeft = GameManager.instance.TimeLeft;
        textElement.text = SecondsToTimerFormat(timeLeft);
        if (timeLeft >= HalfTime)
            textElement.color = Color.Lerp(StartColor, MidColor, (HalfTime - (timeLeft - HalfTime)) / HalfTime);
        else
            textElement.color = Color.Lerp(MidColor, EndColor, (HalfTime - timeLeft) / HalfTime);
    }

    private string SecondsToTimerFormat(float totalSeconds)
    {
        int minutes = (int)(totalSeconds / 60f);
        int seconds = (int)(totalSeconds % 60f);
        int milliseconds = (int)((totalSeconds - 60f * minutes - seconds) * 100f);
        return $"{minutes:D2}:{seconds:D2}:{milliseconds:D2}";
    }
}
