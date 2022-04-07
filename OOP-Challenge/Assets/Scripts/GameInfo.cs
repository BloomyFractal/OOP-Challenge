using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameInfo : MonoBehaviour
{
  //Time variables
  public float time;
  private TextMeshProUGUI timeText;

  //Current player
  private TextMeshProUGUI playerNameDisplay;

  //Current score
  public float score;
  private TextMeshProUGUI scoreText;

  //Script communication
  private DataPersists dataPersists;
  private Hero hero;

    void Start()
    {
     //Scripts Reference
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();
     hero = GameObject.Find("Hero").GetComponent<Hero>();

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

      //Kill hero if time runs out
      if (time <= 0)
      {
        hero.lifeNum = 0;
        Debug.Log("lifeNum = " + hero.lifeNum + ".");
      }
    }
}
