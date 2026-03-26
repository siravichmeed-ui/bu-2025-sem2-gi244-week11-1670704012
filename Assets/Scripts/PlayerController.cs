using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    private InputAction moveAction;
    private InputAction smashAction;
    private InputAction breakAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        smashAction = InputSystem.actions.FindAction("Smash");
        breakAction = InputSystem.actions.FindAction("Break");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
