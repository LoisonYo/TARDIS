using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRotorMovement : MonoBehaviour
{
    private float step;
    private TardisSingleton singleton;
    public bool clockwise = false;

    // Start is called before the first frame update
    void Start()
    {
        singleton = TardisSingleton.GetInstance();
        step = (Mathf.PI / 180.0f) * 6;
        step *= (clockwise) ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(singleton.state == TardisState.Flying)
            transform.Rotate(0.0f, 0.0f, step);
    }
}
