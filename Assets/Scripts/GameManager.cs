using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform PinAnchor;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        SetPins();
        inputManager.OnResetPressed.AddListener(HandleReset);
    }

    private void HandleReset(){
        SetPins();
        ball.ResetBall();
    }


    private void SetPins(){

        if(pinObjects){
            foreach(Transform child in pinObjects.transform){
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }
        pinObjects = null;

        pinObjects = Instantiate(pinCollection, PinAnchor.transform.position, Quaternion.identity, transform);

        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,FindObjectsSortMode.None);
        foreach(FallTrigger pin in fallTriggers){
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }
    private void IncrementScore(){
        score++;
        scoreText.text = $"Score: {score}";
    }
    }

