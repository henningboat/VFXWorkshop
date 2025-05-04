using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int score = 0;
    TextMeshPro scoreText;


    private void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
        UpdateScoreText();
    }

    public void CollectPoint()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        transform.DOPunchScale(Vector3.one*0.1f, 0.1f);
        scoreText.text = "Score: " + score;
    }
}