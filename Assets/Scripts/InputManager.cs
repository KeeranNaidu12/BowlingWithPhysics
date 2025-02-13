using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnSpacePressed = new UnityEvent();
    public UnityEvent OnResetPressed = new UnityEvent();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            OnSpacePressed?.Invoke();
        }

        Vector2 input = Vector2.zero;
        if(Input.GetKey(KeyCode.A)){
            input += Vector2.left;
            Debug.Log(input);
        }
        if(Input.GetKey(KeyCode.D)){
            input += Vector2.right;
            Debug.Log(input);
        }
        OnMove?.Invoke(input);

        if(Input.GetKeyDown(KeyCode.R)){
            OnResetPressed?.Invoke();
            Debug.Log("The game has reset");
        }
    }
}
