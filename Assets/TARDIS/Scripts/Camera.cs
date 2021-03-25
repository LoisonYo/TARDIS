using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private const float RADIUS = 4.0f;
    private const float POSITION_Y = 4.5f;
    private const float ROTATION_X = 22.5f;

    private enum State {Circle};
    private State currentState;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float position_x = -1 * RADIUS * Mathf.Cos(angle);
        float position_z = RADIUS * Mathf.Sin(angle);
        float rotation_y = 90.0f + (angle * 180 / Mathf.PI);
        transform.position = new Vector3(position_x, POSITION_Y, position_z);
        transform.rotation = Quaternion.Euler(ROTATION_X, rotation_y, 0.0f);

        angle += (Mathf.PI / 180) / 100;
    }

    private void Circle()
    {

    }
}
