using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject spawner;
    public GameObject ScoreManager;

    public int checkScore;

    private void Update()
    {

        if (health <= 0) {
            
            checkScore = ScoreManager.GetComponent<Score>().score;
            PlayerPrefs.SetInt("Score", checkScore);

            if (checkScore >= 50)
            {
                SceneManager.LoadScene("Scenes/Win");
            }
            else
            {
                SceneManager.LoadScene("Scenes/GameOver");
            }

            
        }

        healthDisplay.text = health.ToString();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }

}
