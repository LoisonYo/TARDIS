using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : CameraMovement
{
    private const float CENTER_X = -4.8f;
    private const float CENTER_Y = 3.0f;
    private const float CENTER_Z = -24.0f;
    private const float RADIUS = 24.0f;
    private const float SHIFT_X = -Mathf.PI / 32.0f;
    private const float SHIFT_Z = 0.0f;

    private float angle;

    public DoorMovement(GameObject camera) : base(camera)
    {
        this.angle = Mathf.PI / 2;
    }

    public override bool IsFinished()
    {
        return angle > 2.0f;
    }

    public override void Next()
    {
        camera.transform.position = GetPosition(angle);
        camera.transform.rotation = GetRotation(angle);
        angle += (Mathf.PI / 135.0f) * Time.deltaTime;
    }

    public override CameraMovement GetNextMovement()
    {
        return new CatwalkMovement(camera);
    }

    private Vector3 GetPosition(float angle)
    {
        Vector3 result = new Vector3(0.0f, 0.0f, 0.0f);

        result.x = -1 * RADIUS * Mathf.Cos(angle) + CENTER_X;
        result.y = Mathf.Cos(angle) * RADIUS * Mathf.Sin(SHIFT_X) + Mathf.Sin(angle) * RADIUS * Mathf.Sin(SHIFT_Z) + CENTER_Y;
        result.z = RADIUS * Mathf.Sin(angle) + CENTER_Z;

        return result;
    }

    private Quaternion GetRotation(float angle)
    {
        float rtod = 180 / Mathf.PI;
        float x = -Mathf.Sin(angle) * SHIFT_X;
        float y = angle - Mathf.PI;
        float z = Mathf.Cos(angle) * SHIFT_Z;

        return Quaternion.Euler(x * rtod, y * rtod, z * rtod);
    }
}
