using UnityEngine;

public class MouseKeyboardInput : IInputHandler
{
    public bool Raycast(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);
    }

    public Vector3 GetMoveDirection()
    {
        Raycast(out RaycastHit hit);
        return hit.point;
    }

    public float GetRotation()
    {
        return Input.GetMouseButton(1) ? Input.GetAxis("Mouse X") : 0f;
    }

    public float GetZoom()
    {
        return Input.GetAxis("Mouse ScrollWheel") * -5f;
    }

}
