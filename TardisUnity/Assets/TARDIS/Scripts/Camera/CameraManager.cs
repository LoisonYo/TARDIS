using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CameraMovement current;

    void Start()
    {
        current = new DoorMovement(this.gameObject);
    }

    void Update()
    {
        if (current.IsFinished())
            current = current.GetNextMovement();
        else    
            current.Next();       
    }
}
