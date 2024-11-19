using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRoom : MonoBehaviour
{
    public GameObject[] HideObjects;
    public GameObject TimerObject;
    public float timerMax = 10f;
    private float timerNow;
    public bool timerActive = false;

    public Transform Head;
    public O2Gueage o2;
    public smoke_down smoke;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            timerNow -= Time.deltaTime;
            if(timerNow <= 0)
            {
                timerActive = false;
                timerNow = 0;
                gameObject.SetActive(false);
                foreach(GameObject obj in HideObjects)
                {
                    if(obj != null)
                    {
                        obj.SetActive(true);
                    }
                }
                o2.RestartTimer();
                smoke.ResetSmoke();
            }
        }
        TimerObject.transform.localScale = new Vector3(timerNow / timerMax, 1, 1);
    }

    public void Trigger()
    {
        gameObject.transform.position = new Vector3(Head.position.x, 0, Head.position.z);
        gameObject.SetActive(true);
        foreach(GameObject obj in HideObjects)
        {
            if(obj != null)
            {
                obj.SetActive(false);
            }
        }
        timerNow = timerMax;
        timerActive = true;
    }
}
