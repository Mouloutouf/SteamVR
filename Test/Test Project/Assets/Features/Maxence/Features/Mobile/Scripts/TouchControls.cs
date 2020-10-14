using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TouchControls : MonoBehaviour
{
    Vector3 firstTouchPosition;
    Camera cam;
    public float yMax, yMin, xMax, xMin;

    public float zoomMax, zoomMin;
    public float factor = 0.01f;

    void Start()
    {
        if (cam == null) cam = Camera.main;
    }

    void Update()
    {
        InputMove();
    }

    private void InputMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Zoom();
        }
        else if (Input.GetMouseButton(0))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 currentTouchPosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 moveDirection = firstTouchPosition - currentTouchPosition;
        Vector3 camDirection = cam.transform.position;
        camDirection += moveDirection;

        Vector3 framedDirection = new Vector3(Mathf.Clamp(camDirection.x, xMin, xMax), Mathf.Clamp(camDirection.y, yMin, yMax), camDirection.z);
        cam.transform.position = framedDirection;
    }

    private void Zoom()
    {
        Touch firstTouch = Input.GetTouch(0);
        Touch secondTouch = Input.GetTouch(1);

        Vector3 firstTouchPreviousPosition = firstTouch.position - firstTouch.deltaPosition;
        Vector3 secondTouchPreviousPosition = secondTouch.position - secondTouch.deltaPosition;

        float previousDistance = (firstTouchPreviousPosition - secondTouchPreviousPosition).magnitude;
        float currentDistance = (firstTouch.position - secondTouch.position).magnitude;

        float bruteDifference = currentDistance - previousDistance;
        float difference = bruteDifference * factor;

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - difference, zoomMin, zoomMax);
    }
}
