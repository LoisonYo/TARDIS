using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleMovement : CameraMovement
{
    private const float CENTER_X = 0.0f;
    private const float CENTER_Y = 3.2f;
    private const float CENTER_Z = 0.0f;
    private const float RADIUS = 1.8f;
    private const float SHIFT_X = 0.0f;
    private const float SHIFT_Z = 0.0f;

    private float angle;

    public ConsoleMovement(GameObject camera) : base(camera)
    {
        angle = 0.0f;
    }

    public override bool IsFinished()
    {
        return angle < Mathf.PI * -2;
    }

    public override void Next()
    {
        camera.transform.position = GetPosition(angle);
        camera.transform.rotation = GetRotation(angle);
        angle -= (Mathf.PI / 10.0f) * Time.deltaTime;
    }

    public override CameraMovement GetNextMovement()
    {
        return new TopView(camera);
    }

    private Vector3 GetPosition(float angle)
    {
        Vector3 result = new Vector3(0.0f, 0.0f, 0.0f);

        result.x = -1.0f * RADIUS * Mathf.Cos(angle) + CENTER_X;
        result.y = Mathf.Cos(angle) * RADIUS * Mathf.Sin(SHIFT_X) + Mathf.Sin(angle) * RADIUS * Mathf.Sin(SHIFT_Z) + CENTER_Y;
        result.z = RADIUS * Mathf.Sin(angle) + CENTER_Z;

        return result;
    }

    private Quaternion GetRotation(float angle)
    {
        float rtod = 180.0f / Mathf.PI;
        float y = angle + Mathf.PI / 2.0f;
        float z = Mathf.Cos(angle) * SHIFT_Z;

        return Quaternion.Euler(20.0f, y * rtod, z * rtod);
    }
}
