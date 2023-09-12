using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;



    private void Update()
    {
        scoreText.text = "score: " + PlayerScore.Instance.GetScore();
    }


}
