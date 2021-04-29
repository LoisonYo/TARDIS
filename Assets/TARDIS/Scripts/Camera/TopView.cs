using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopView : CameraMovement
{
    private const float CENTER_X = 0.0f;
    private const float CENTER_Y = 4.0f;
    private const float CENTER_Z = 0.0f;
    private const float RADIUS = 5.5f;
    private const float SHIFT_X = 0.0f;
    private const float SHIFT_Z = 0.0f;

    private bool setup;

    public TopView(GameObject camera) : base(camera)
    {
        this.setup = false;
    }

    public override bool IsFinished()
    {
        return false;
    }

    public override void Next()
    {
        if(!setup)
        {
            camera.transform.position = GetPosition();
            camera.transform.rotation = GetRotation();
            setup = true;
        }
    }

    public virtual CameraMovement GetNextMovement()
    {
        return null;
    }

    private Vector3 GetPosition()
    {
        Vector3 result = new Vector3(0.0f, 0.0f, 0.0f);

        result.x = 2.2f;
        result.y = 5.5f;
        result.z = -3.5f;

        return result;
    }

    private Quaternion GetRotation()
    {
        float rtod = 180.0f / Mathf.PI;
        float x = 0.0f;
        float y = 25.0f;
        float z = 0.0f;

        return Quaternion.Euler(x * rtod, y * rtod, z * rtod);
    }
}
