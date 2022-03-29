using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInfo : MonoBehaviour
{
  //HUD variables
  public float time;
  private TextMeshProUGUI timeText;

  //Current player
  private TextMeshProUGUI playerNameDisplay;

  //Current score
  public float score;
  private TextMeshProUGUI scoreText;

  //Script communication
  private DataPersists dataPersists;

    void Start()
    {

     //Data Reference
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();

     //Define Time variables
     time = 100;
     timeText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();

     //Define Player variables
     playerNameDisplay = GameObject.Find("playerName").GetComponent<TextMeshProUGUI>();

     playerNameDisplay.text = dataPersists.playerName;

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
