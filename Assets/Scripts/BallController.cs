using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;


    private Rigidbody ballRB;
    private bool isBallLaunched;
    private InputManager inputManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    // Update is called once per frame
    private void LaunchBall()
    {
        if(isBallLaunched) return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
