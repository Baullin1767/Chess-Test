using UnityEngine;

public interface IInputHandler
{
    bool Raycast(out RaycastHit hit);
    Vector3 GetMoveDirection();
    float GetRotation();
    float GetZoom();
}
