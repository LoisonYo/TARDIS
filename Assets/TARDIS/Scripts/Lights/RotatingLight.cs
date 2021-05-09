using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLight : TardisLight
{
    private const float WAIT_TIME = 0.2f;

    private float time;
    private int index;

    public RotatingLight(string tag, bool children = false) : base(tag, children)
    {
        time = WAIT_TIME;
        index = 0;
    }

    public void Rotate(float ms)
    {
        time += ms;
        if(time >= WAIT_TIME)
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
        SetPartState(ConvertIndex(index + 17));
        SetPartState(ConvertIndex(index + 34));
    }

    private void SetPartState(int index)
    {
        Turn(true, ConvertIndex(index));
        Turn(true, ConvertIndex(index + 1));
        Turn(true, ConvertIndex(index + 2));
        Turn(true, ConvertIndex(index + 3));
        Turn(true, ConvertIndex(index + 4));
    }

    private int ConvertIndex(int index)
    {
        return index % lights.Length;
    }
}
