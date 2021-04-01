using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private enum State { DOOR, AROUND, CATWALK };

    public float speed = 1.0f;

    private float angle;
    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        angle = Mathf.PI / 2;
        currentState = State.DOOR;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.DOOR:
                Door();
                break;
            case State.AROUND:
                Around();
                break;
            case State.CATWALK:
                CatWalk();
                break;
        }
    }

    void Door()
    {
        float CENTER_X = -4.8f;
        float CENTER_Y = 3.0f;
        float CENTER_Z = -24.0f;
        float RADIUS = 24.0f;
        float SHIFT_X = -Mathf.PI / 32.0f;
        float SHIFT_Z = 0.0f;

        transform.position = GetCirclePosition(CENTER_X, CENTER_Y, CENTER_Z, RADIUS, angle, SHIFT_X, SHIFT_Z);
        transform.rotation = GetCircleBehindRotation(angle, SHIFT_X, SHIFT_Z);
        angle += (Mathf.PI / 135.0f) * Time.deltaTime;

        if (angle > 2.0f)
        {
            currentState = State.AROUND;
            angle = 0.0f;
        }
    }

    void Around()
    {
        float CENTER_X = 0.0f;
        float CENTER_Y = 4.5f;
        float CENTER_Z = 0.0f;
        float RADIUS = 4.0f;
        float SHIFT_X = 0.0f;
        float SHIFT_Z = 0.0f;

        transform.position = GetCirclePosition(CENTER_X, CENTER_Y, CENTER_Z, RADIUS, angle, SHIFT_X, SHIFT_Z);
        transform.rotation = FixCenter(angle, CENTER_X, CENTER_Y, 3.0f, SHIFT_X, SHIFT_Z);
        angle += (Mathf.PI / 50.0f) * Time.deltaTime;
    }

    void CatWalk()
    {

    }

    Vector3 GetCirclePosition(float center_x, float center_y, float center_z, float radius, float angle, float shift_x, float shift_z)
    {
        Vector3 result = new Vector3(0.0f, 0.0f, 0.0f);

        result.x = -1 * radius * Mathf.Cos(angle) + center_x;
        result.y = Mathf.Cos(angle) * radius * Mathf.Sin(shift_x) + Mathf.Sin(angle) * radius * Mathf.Sin(shift_z) + center_y;
        result.z = radius * Mathf.Sin(angle) + center_z;

        return result;
    }

    Quaternion GetCircleBehindRotation(float angle, float shift_x, float shift_z)
    {
        float rtod = 180 / Mathf.PI;
        float x = -Mathf.Sin(angle) * shift_x;
        float y = angle - Mathf.PI;
        float z = Mathf.Cos(angle) * shift_z;

        return Quaternion.Euler(x * rtod, y * rtod, z * rtod);
    }

    Quaternion FixCenter(float angle, float point_x, float point_y, float point_z, float shift_x, float shift_z)
    {
        float rtod = 180 / Mathf.PI;
        float x = Mathf.PI / 11;
        float y = angle + Mathf.PI / 2;
        float z = Mathf.Cos(angle) * shift_z;

        return Quaternion.Euler(x * rtod, y * rtod, z * rtod);
    }
}
