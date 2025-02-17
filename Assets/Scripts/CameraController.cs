using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private float zoomSpeed = 4f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 30f;

    public void Rotate(float rotation)
    {
        if (rotation != 0)
        {
            transform.RotateAround(center.position, Vector3.up, rotation * rotationSpeed);
        }
    }

    public void Zoom(float zoomChange)
    {
        if (zoomChange != 0)
        {
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - zoomChange * zoomSpeed, minZoom, maxZoom);
        }
    }
}
