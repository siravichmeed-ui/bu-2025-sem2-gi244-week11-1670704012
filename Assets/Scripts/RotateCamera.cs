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

    }
}
