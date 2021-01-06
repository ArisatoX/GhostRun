using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    public Text scoreDisplay;
    public int limit;

    private void Update()
    {
        string scoreText = score.ToString() + "/" + limit;
        scoreDisplay.text = scoreText;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        Destroy(other.gameObject);
    }
}
