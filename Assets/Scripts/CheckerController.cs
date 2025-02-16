using UnityEngine;

public class CheckerController : MonoBehaviour
{

    public void MoveTo(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }
}
