using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public int score;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        score = 0;
    }
    public int GetScore()
    {
        return score;
    }
}
