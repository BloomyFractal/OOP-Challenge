using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInfo : MonoBehaviour
{
  public float time;
  private TextMeshProUGUI timeText;

  public float score;
  private TextMeshProUGUI scoreText;

    void Start()
    {
     //Define Time variables
     time = 100;
     timeText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();

     //Define Score variables
     scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
     //Display time
     timeText.text = "Time: " + time.ToString("000");
     if (time > 0)
     {
       time -= Time.deltaTime;
     }

     //Display Score
     scoreText.text = "Score: " + score.ToString("0 000 000");

    }
}
