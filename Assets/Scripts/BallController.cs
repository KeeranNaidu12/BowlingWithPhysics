using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;


    private Rigidbody ballRB;
    private bool isBallLaunched;
    [SerializeField]private InputManager inputManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }

    // Update is called once per frame
    private void LaunchBall()
    {
        if(isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
