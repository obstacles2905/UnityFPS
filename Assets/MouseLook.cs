using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes {
        XY = 0,
        X = 1,
        Y = 2
    }

    public RotationAxes axes = RotationAxes.XY;

    public float horizontalSensitivity = 9.0f;
    public float verticalSensitivity = 9.0f;

    public float minVerticalAngle = -45.0f;
    public float maxVerticalAngle = 45.0f;

    private float _rotationY = 0; //angle of the vertical turn

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rotationX;
        float delta; 

        switch (axes)
        {
            case RotationAxes.XY:
                _rotationY -= Input.GetAxis("Mouse Y") * verticalSensitivity;
                _rotationY = Mathf.Clamp(_rotationY, minVerticalAngle, maxVerticalAngle);

                delta = Input.GetAxis("Mouse X") * horizontalSensitivity;
                rotationX = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotationY, rotationX, 0);
                break;
            case RotationAxes.X:
                delta = Input.GetAxis("Mouse X") * horizontalSensitivity;
                rotationX = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(0, rotationX, 0);
                break;
            case RotationAxes.Y:
                _rotationY -= Input.GetAxis("Mouse Y") * verticalSensitivity; // increase the rotation angle according to the mouse move
                _rotationY = Mathf.Clamp(_rotationY, minVerticalAngle, maxVerticalAngle); // fix the rotation angle between min and max values

                rotationX = transform.localEulerAngles.y; //adjust look only for vertical axe

                transform.localEulerAngles = new Vector3(_rotationY, rotationX, 0);
                break;
            default:
                break;
        }
    }
}
