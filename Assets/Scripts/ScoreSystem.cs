using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] float scoreMultiplier;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] PlayerHealth playerHealth;

    float score;

    void Update()
    {
        if (playerHealth.isDead)
        {
            finalScoreText.text = "Your Score: " + Mathf.FloorToInt(score).ToString();
            gameObject.SetActive(false);
            return;
        }
        score += scoreMultiplier * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
}
