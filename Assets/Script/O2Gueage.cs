using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Gueage : MonoBehaviour
{
    private Animator animator;
    public string animator_string_name;
    public GameObject smoke_obj;
    private float smoke_y;
    public GameObject head;
    private float head_y;
    public float height_ratio = 0.7f;
    public bool timerActive = true;
    public float O2Max = 600;
    private float O2now;
    public float decrese_insmoke = 1;
    public float increse_outsmoke_max = 0.5f;
    public float increase_coef = 2;

    public DeathRoom death;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        smoke_y = smoke_obj.transform.position.y;
        head_y = head.transform.position.y;
        O2now = O2Max;
    }

    // Update is called once per frame
    void Update()
    {
        head_y = head.transform.position.y;
        if (timerActive)
        {
            if (head_y / smoke_y >= height_ratio)
            {
                O2now -= decrese_insmoke;
                if (O2now <= 0)
                {
                    O2now = 0;
                }
            }
            else
            {
                float y_dif = smoke_y - head_y;
                if (y_dif * increase_coef >= increse_outsmoke_max)
                {
                    O2now += increse_outsmoke_max;
                }
                else
                {
                    O2now += y_dif * increase_coef;
                }
                if (O2now >= O2Max)
                {
                    O2now = O2Max;
                }
            }
            if (O2now <= 0)
            {
                timerActive = false;
                death.Trigger();
            }
        }
        animator.SetFloat(animator_string_name, O2now / O2Max);
    }

    public void RestartTimer()
    {
        O2now = O2Max;
        timerActive = true;
    }
}
