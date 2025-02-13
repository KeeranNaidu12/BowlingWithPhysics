using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform LaunchIndicator;

    private bool isBallLaunched = false;
    private Rigidbody ballRB;
    [SerializeField] private InputManager inputManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        ResetBall();
    }

    // Update is called once per frame
    private void LaunchBall()
    {
        if(isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(LaunchIndicator.forward * force, ForceMode.Impulse);
        LaunchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall(){
        isBallLaunched = false;
        ballRB.isKinematic = true;
        LaunchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }
}
