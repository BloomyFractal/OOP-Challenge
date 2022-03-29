using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class DataPersists : MonoBehaviour
{
  public DataPersists dataPersists;

  private static TMP_InputField inputField;

  //Level UI variables
  public string playerName;//The one set in EnterName
  private TextMeshProUGUI playerNameDisplay;//The one in Level

  public float score;
  private TextMeshProUGUI scoreText;

  public string highScorePlayer;//The one saved in JSON
  private TextMeshProUGUI highScorePlayerText;//The JSON name displayed in Level

  public float highScoreNum;//The one saved in JSON
  private TextMeshProUGUI highScoreNumText;//The JSON number displayed in Level


  public float difficulty;


    //Singleton
    private void Awake()
    {

     if (dataPersists != null)
      {
        Destroy(gameObject);
        return;
      }

      dataPersists = this;
      DontDestroyOnLoad(gameObject);

    }

    void Start()
    {

    }

    void Update()
    {
      //EnterName definitions
      if (SceneManager.GetActiveScene().name == "EnterName")
      {
       inputField = GameObject.Find("NameField").GetComponent<TMP_InputField>();
      }

      //Level definitions
      if (SceneManager.GetActiveScene().name == "Level")
      {
       playerNameDisplay = GameObject.Find("playerName").GetComponent<TextMeshProUGUI>();

       playerNameDisplay.text = playerName;
      }
    }

    public void SetPlayerName()
    {
      playerName = inputField.text;
      Debug.Log("playerName = " + playerName + "." );
      SceneManager.LoadScene("Level");
    }
}
