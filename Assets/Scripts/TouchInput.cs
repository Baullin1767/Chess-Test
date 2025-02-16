using UnityEngine;

public class TouchInput : IInputHandler
{
    private bool isDraggingChecker = false;
    private float previousPinchDistance;
    Vector3 prefPos;


    public bool Raycast(out RaycastHit hit)
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);


            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                && Physics.Raycast(ray, out hit))
            {
                return true;
            }
            else
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        }
        else
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);

        return false;
    }

    public Vector3 GetMoveDirection()
    {
        Raycast(out RaycastHit hit);
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    prefPos = hit.point;
                }
            }
        }
        return prefPos;
    }

    public float GetRotation()
    {
        if (Input.touchCount == 1 && !isDraggingChecker)
        {
            return Input.GetTouch(0).deltaPosition.x * 0.2f;
        }

        return 0f;
    }

    public float GetZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            float currentDistance = Vector2.Distance(touch0.position, touch1.position);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                previousPinchDistance = currentDistance;
                return 0f;
            }

            float zoomChange = (currentDistance - previousPinchDistance) * 0.01f;
            previousPinchDistance = currentDistance;

            return zoomChange;
        }

        return 0f;
    }
}
