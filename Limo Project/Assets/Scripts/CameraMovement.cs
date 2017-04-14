using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Vector3 lastPosition;
    public float mouseSensivity = 100f;
    void Start () {

    }


    void Update () {
        if (Input.GetMouseButtonDown(2)) {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(2)) {
            Vector3 offset = lastPosition - Input.mousePosition;
            transform.Translate(new Vector3(offset.x / mouseSensivity, offset.y / mouseSensivity, 0));
            lastPosition = Input.mousePosition;
        }
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -4, 92),
            Mathf.Clamp(transform.position.y, -2f, 4f),
            -10
        );
    }

}
