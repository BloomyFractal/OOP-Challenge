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
  public string playerName;

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
     difficulty = 1;
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
       //High Score definitions
       highScoreNumText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();

       highScoreNumText.text = "High Score: " + highScoreNum.ToString("0 000 000");
      }
    }

    public void SetPlayerName()
    {
      playerName = inputField.text;
      Debug.Log("playerName = " + playerName + "." );
      SceneManager.LoadScene("Level");
    }
}
