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

  //Enemies variables
  private GameObject enemies;

  //Current score
  public float score;
  private TextMeshProUGUI scoreText;

  //Script communication
  private DataPersists dataPersists;
  private Hero hero;
  private Transform heroTrans;

  //Finish variables
  private Transform finishFlagTrans;

  //Finish Panel variables
  public GameObject finishPanel;
  public TextMeshProUGUI panelScore;

  private float lifeBonus;
  public TextMeshProUGUI lifeBonusText;

  private float timeBonus;
  public TextMeshProUGUI timeBonusText;

  public TextMeshProUGUI difficultyBonusText;

  private float totalScore;
  public TextMeshProUGUI totalScoreText;

  //Finish Options Panel variables
  public GameObject finishOptPanel;


    void Start()
    {
     //Scripts Reference
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();
     hero = GameObject.Find("Hero").GetComponent<Hero>();
     heroTrans = GameObject.Find("Hero").GetComponent<Transform>();

     //Define Time variables
     time = 100;
     timeText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();

     //Define Player variables
     playerNameDisplay = GameObject.Find("playerName").GetComponent<TextMeshProUGUI>();

     playerNameDisplay.text = dataPersists.playerName;

     //Define enemies variables
     enemies = GameObject.Find("Enemies");

     //Define Score variables
     scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

     //Define Flag
     finishFlagTrans = GameObject.Find("Flagcolumn").GetComponent<Transform>();
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

      LevelEnd();
    }

    private void LevelEnd()
    {
     if (heroTrans.position.x < finishFlagTrans.position.x)
     {
       //Disable enemies
       enemies.SetActive(false);

       //Stop time
       Time.timeScale = 0;

       //Display Finish panel
       finishPanel.SetActive(true);

       //Score text
       panelScore.text = "Score     " + score.ToString("0 000 000");

       //Life Bonus text
       lifeBonus = hero.lifeNum * 1000;
       lifeBonusText.text = "Life Bonus     " + lifeBonus;

       //Time Bonus text
       timeBonus = Mathf.Round(time);
       float timeBonusModifier = timeBonus * 100;
       timeBonusText.text = "Time Bonus     " + timeBonusModifier;

       //Difficulty Bonus Text
       difficultyBonusText.text = "Difficulty Bonus    " + "x " + dataPersists.difficulty;

       //Total Score Text
       totalScore = (score + lifeBonus + timeBonusModifier) * dataPersists.difficulty;
       totalScoreText.text = "Total Score    " + totalScore;

       //Go from Finish to Finish Options
       if (finishPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Space) && finishPanel != null)
       {
         finishPanel.SetActive(false);
         finishOptPanel.SetActive(true);
       }

     }
    }
}
