using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Pickups : MonoBehaviour
{
    public TMP_Text scoreText;

    public void Start()
    {
        Scoring.totalScore = 0;
        scoreText.text = "SCORE: " + Scoring.totalScore;
    }
    public void Update()
    {
        if (Scoring.totalScore >=10)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex + 1 >= 3) 
            {
                SceneManager.LoadScene("EndGame"); 
            }
            SceneManager.LoadScene(currentSceneIndex + 1);
            Scoring.totalScore = 0;
            
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Crystal" || collision.tag =="StarPoint")
        {
            Scoring.totalScore++;
            AudioManagement.instance.PlaySfx(1);
            scoreText.text = "SCORE: " + Scoring.totalScore;
            Debug.Log(Scoring.totalScore);
            Destroy(collision.gameObject);

        }

    }
}
