using UnityEngine;

public class InputManager : MonoBehaviour
{
    private IInputHandler inputHandler;
    private CameraController cameraController;
    CheckerController checker;

    void Start()
    {
        inputHandler = new TouchInput();

        cameraController = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        if (inputHandler.Raycast(out RaycastHit hit) && hit.collider.CompareTag("Checker"))
        {
            Vector3 moveDirection = inputHandler.GetMoveDirection();
            checker = hit.collider.GetComponent<CheckerController>();
            checker.MoveTo(new Vector3(moveDirection.x, 0, moveDirection.z));
        }
        else
        {
            if(checker!=null)
                checker.MoveTo(new Vector3(checker.transform.position.x, 0, checker.transform.position.z));
            checker = null;
            float rotation = inputHandler.GetRotation();
            float zoom = inputHandler.GetZoom();
            cameraController.Rotate(rotation);
            cameraController.Zoom(zoom);
        }
    }
}
