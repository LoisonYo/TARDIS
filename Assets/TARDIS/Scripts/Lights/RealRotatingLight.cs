using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealRotatingLight : Light
{
    private const float WAIT_TIME = 0.6f;

    private float time;
    private int index;

    public RealRotatingLight(string tag, bool children = false) : base(tag, children)
    {
        time = WAIT_TIME;
        index = lights.Length - 1;
    }

    public void Rotate(float ms)
    {
        time += ms;
        if (time >= WAIT_TIME)
        {
            time -= WAIT_TIME;
            SetState();
        }
    }

    private void SetState()
    {
        TurnAll(false);

        index++;
        SetPartState(ConvertIndex(index));
        SetPartState(ConvertIndex(index + 5));
        SetPartState(ConvertIndex(index + 11));
    }

    private void SetPartState(int index)
    {
        Turn(true, ConvertIndex(index));
        Turn(true, ConvertIndex(index + 1));
        Turn(true, ConvertIndex(index + 2));
    }

    private int ConvertIndex(int index)
    {
        return index % lights.Length;
    }
}
