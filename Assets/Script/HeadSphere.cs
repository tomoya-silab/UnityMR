using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSphere : MonoBehaviour
{
    private Animator _animator;
    public string animator_Parameter;
    public GameObject Smoke_obj;
    public float Smoke_Height;
    private float Height_Ratio;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Smoke_Height = Smoke_obj.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float height = transform.position.y;
        Height_Ratio = height / Smoke_Height;
        if (Height_Ratio > 1)
        {
            Height_Ratio = 1;
        }
        if(Height_Ratio < 0)
        {
            Height_Ratio = 0;
        }
        _animator.SetFloat(animator_Parameter, Height_Ratio);
    }
}
