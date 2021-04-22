using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light
{
    private bool children;
    private GameObject[] lights;
    private bool active;

    public Light(string tag, bool children = false)
    {
        this.children = children;
        lights = GameObject.FindGameObjectsWithTag(tag);
        active = true;

        TurnOff();
    }

    public void TurnOn()
    {
        if(active == false)
            Turn(true);
    }

    public void TurnOff()
    {
        if (active == true)
            Turn(false);
    }

    private void Turn(bool on)
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
}
