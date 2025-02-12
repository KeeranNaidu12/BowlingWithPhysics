using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;
    private void Start()
    {
        pins = FindObjectsOfType<FallTrigger>(true);
        foreach(FallTrigger pin in pins){
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }
    private void IncrementScore(){
        score++;
        scoreText.text = $"Score: {score}";
    }
    }

