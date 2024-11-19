using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke_down : MonoBehaviour
{
    public float startheight = 1.8f;
    public float endheight = 0.4f;
    public float ratesecond = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        ResetSmoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y > endheight)
        {
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y - (Time.deltaTime * ratesecond), 0);
        }
    }

    public void ResetSmoke()
    {
        gameObject.transform.position = new Vector3(0, startheight, 0);
    }
}
