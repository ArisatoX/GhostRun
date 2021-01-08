using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetScore : MonoBehaviour
{
    public int score;
    public GameObject ScoreText;

    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }
}
