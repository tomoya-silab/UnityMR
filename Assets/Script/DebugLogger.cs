using Oculus.VoiceSDK.UX;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugLogger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] LogText = null;
    [SerializeField] private string TimeFormat = "HH:mm:ss";
    private long[] Ticks = null;
    private string[] names = null;
    private string[] logs = null;


    private void Awake()
    {
        Ticks = new long[LogText.Length];
        names = new string[LogText.Length];
        logs = new string[LogText.Length];
        for (int i = 0; i < LogText.Length; i++)
        {
            Ticks[i] = 0;
            names[i] = string.Empty;
            logs[i] = string.Empty;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLog(string name, string log)
    {
        if (Ticks == null || names == null|| logs == null)
        {
            return;
        }

        long time = DateTime.Now.Ticks;

        for(int i = 0; i < LogText.Length;i++)
        {
            if (string.IsNullOrEmpty(logs[i]))
            {
                Ticks[i] = time;
                names[i] = name;
                logs[i] = log;
                UpdateLog();
                return;
            }
        }

        for(int i = 0; i < LogText.Length; i++)
        {
            Ticks[i] = i < LogText.Length - 1 ? Ticks[i + 1] : time;
            names[i] = i < LogText.Length - 1 ? names[i + 1] : name;
            logs[i] = i < LogText.Length - 1 ? logs[i + 1] : log;
        }
        UpdateLog();
    }

    private void UpdateLog()
    {
        for(int i = 0;i < LogText.Length; i++)
        {
            if (string.IsNullOrEmpty(logs[i]))
            {
                LogText[i].text = string.Empty;
            }
            else
            {
                LogText[i].text = $"{new DateTime(Ticks[i]).ToString(TimeFormat)} {names[i]} {logs[i]}";
            }
        }
    }
}
