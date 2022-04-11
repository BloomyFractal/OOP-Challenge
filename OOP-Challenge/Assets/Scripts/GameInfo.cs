using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

  //The JSON highscore and name showed in Level
  private TextMeshProUGUI highScoreText;

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

  public RectTransform navArrow;
  private Vector2 arrowFacesRetry;
  private Vector2 arrowFacesReturn;

  //Game Over variables
  public GameObject gameOverPanel;


    void Start()
    {
     //Scripts Reference
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();
     hero = GameObject.Find("Hero").GetComponent<Hero>();
     heroTrans = GameObject.Find("Hero").GetComponent<Transform>();

     //Define Time variables
     Time.timeScale = 1;
     time = 5;
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

     //Finish Options Panel Arrow positions
     arrowFacesRetry = new Vector2(navArrow.anchoredPosition.x+0,navArrow.anchoredPosition.y+0);

     arrowFacesReturn = new Vector2(navArrow.anchoredPosition.x+0,navArrow.anchoredPosition.y-200);

     navArrow.anchoredPosition = arrowFacesRetry;

     //Data
     dataPersists.LoadNameAndScore();

     Debug.Log("High Score = " + dataPersists.highScoreNum + ".");
     Debug.Log("Best Player is " + dataPersists.playerName + ".");
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

      //Display High Score
      highScoreText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();

      highScoreText.text = "High Score: " + dataPersists.highScorePlayer + " " + dataPersists.highScoreNum.ToString("0 000 000");

      //Kill hero if time runs out
      if (time <= 0)
      {
        hero.lifeNum = 0;
        Debug.Log("lifeNum = " + hero.lifeNum + ".");
      }

      //Finish Options Set up
      if (finishOptPanel.activeInHierarchy || gameOverPanel.activeInHierarchy)
      {
       navArrow = GameObject.Find("NavigationArrow").GetComponent<RectTransform>();
      }

      LevelEnd();
      GameOver();
    }

    private void LevelEnd()
    {
     if (heroTrans.position.x < finishFlagTrans.position.x)
     {
       //Disable enemies
       if (enemies != null)
       {
         enemies.SetActive(false);
       }

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

       //Finish Options Set up
       if (finishOptPanel.activeInHierarchy)
       {
        navArrow = GameObject.Find("NavigationArrow").GetComponent<RectTransform>();

        //Navigate between "Retry" and "Return to Title Screen"
        if (navArrow.anchoredPosition == arrowFacesRetry && Input.GetKeyDown(KeyCode.DownArrow))
        {
         navArrow.anchoredPosition = arrowFacesReturn;
        }

        if (navArrow.anchoredPosition == arrowFacesReturn && Input.GetKeyDown(KeyCode.UpArrow))
        {
         navArrow.anchoredPosition = arrowFacesRetry;
        }

        //Reset level if "Retry" is selected and ReturnKey is pressed
        if (navArrow.anchoredPosition == arrowFacesRetry && Input.GetKeyDown(KeyCode.Return))
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Save data and return to title screen if Return button is selected and return key is pressed
        if (navArrow.anchoredPosition == arrowFacesReturn && Input.GetKeyDown(KeyCode.Return))
        {
         CheckForScore();

         //Return to Title screen
         SceneManager.LoadScene("TitleScreen");
        }
       }
     }
    }

    private void GameOver()
    {
     if (hero.lifeNum == 0)
     {
       //Stop time
       Time.timeScale = 0;

       //Summon the dreadful Game Over screen
       gameOverPanel.SetActive(true);

       //Navigate between "Retry" and "Return to Title Screen"
       //Downward
       if (navArrow.anchoredPosition == arrowFacesRetry && Input.GetKeyDown(KeyCode.DownArrow))
       {
        navArrow.anchoredPosition = arrowFacesReturn;
       }

       //Upward
       if (navArrow.anchoredPosition == arrowFacesReturn && Input.GetKeyDown(KeyCode.UpArrow))
       {
        navArrow.anchoredPosition = arrowFacesRetry;
       }

       //Reset level if "Retry" is selected and ReturnKey is pressed
       if (navArrow.anchoredPosition == arrowFacesRetry && Input.GetKeyDown(KeyCode.Return))
       {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }

       //Back to Title Screen
       if (navArrow.anchoredPosition == arrowFacesReturn && Input.GetKeyDown(KeyCode.Return))
       {
        TitleScreen();
       }

     }
    }

    //Click Functions
    public void CheckForScore()
    {
     //Save data in case of new high score
     if (totalScore > dataPersists.highScoreNum)
     {
      dataPersists.highScoreNum = totalScore;
      dataPersists.highScorePlayer = dataPersists.playerName;

      dataPersists.SaveNameAndScore();

      Debug.Log("High Score = " + dataPersists.highScoreNum + ".");
      Debug.Log("Best Player is " + dataPersists.playerName + ".");

      //Return to Title screen
      SceneManager.LoadScene("TitleScreen");
     }
    }

    //Restart level from the beginning
    public void Retry()
    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Back to Title Screen
    public void TitleScreen()
    {
      SceneManager.LoadScene("TitleScreen");
    }
}
