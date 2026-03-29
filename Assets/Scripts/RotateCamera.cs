using UnityEngine;
using UnityEngine.InputSystem;


public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    private InputAction moveAction;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        var move = moveAction.ReadValue<Vector2>();
        var h = move.x;
        transform.Rotate(Vector3.up, rotationSpeed * h * Time.deltaTime);
    }
}
