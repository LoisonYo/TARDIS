using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement
{
    protected GameObject camera;

    public CameraMovement(GameObject camera)
    {
        this.camera = camera;
    }

    public virtual bool IsFinished()
    {
        return true;
    }

    public virtual void Next()
    {
        
    }

    public virtual CameraMovement GetNextMovement()
    {
        return null;
    }
}
