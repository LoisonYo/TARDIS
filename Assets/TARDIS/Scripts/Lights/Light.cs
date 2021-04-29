﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light
{
    protected bool children;
    protected GameObject[] lights;
    protected bool active;

    public Light(string tag, bool children = false)
    {
        this.children = children;
        lights = GameObject.FindGameObjectsWithTag(tag);
        active = true;

        TurnAllOff();
    }

    public void TurnAllOn()
    {
        if(active == false)
            TurnAll(true);
    }

    public void TurnAllOff()
    {
        if (active == true)
            TurnAll(false);
    }

    protected void TurnAll(bool on)
    {
        foreach (GameObject light in lights)
        {
            light.active = on;

            if(children == true)
            {
                Transform[] allChildren = light.GetComponentsInChildren<Transform>();
                foreach (Transform child in allChildren)
                {
                    child.gameObject.GetComponent<Renderer>().enabled = on;
                }
            }
        }

        active = on;
    }

    protected void Turn(bool on, int index)
    {
        GameObject light = lights[index];

        light.active = on;

        if (children == true)
        {
            Transform[] allChildren = light.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                child.gameObject.GetComponent<Renderer>().enabled = on;
            }
        }
    }
}
