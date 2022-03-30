using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class DataPersists : MonoBehaviour
{
  public DataPersists dataPersists;

  public static TMP_InputField inputField;

  //EnterName UI variables
  private int nameLength;
  private TextMeshProUGUI nameLengthText;

  //Name warnings
  private TextMeshProUGUI nameTooShortWarning;
  private TextMeshProUGUI nameTooLongWarning;

  //Submit Button Reference
  private Button submit;

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

       submit = GameObject.Find("Submit").GetComponent<Button>();

       nameLengthText = GameObject.Find("NameLength").GetComponent<TextMeshProUGUI>();

       //Check for name Length
       nameLength = inputField.text.Length;

       nameLengthText.text = "Name length: " + nameLength;

       //Show Short Warning if name is too short and disable Submit
       if (inputField.text.Length < 2 && nameTooLongWarning != null)
       {
         nameTooShortWarning.enabled = true;
         nameTooLongWarning.enabled = false;

         submit.enabled = false;
       }

       //Show Long Warning if name is too long and disable Submit
       else if (inputField.text.Length > 14 && nameTooShortWarning != null)
       {
         nameTooShortWarning.enabled = false;
         nameTooLongWarning.enabled = true;

         submit.enabled = false;
       }
       //Hide warnings if name isn't too short nor too long and enable Submit
       else if (nameTooShortWarning != null && nameTooLongWarning != null)
       {
         nameTooShortWarning.enabled = false;
         nameTooLongWarning.enabled = false;

         submit.enabled = true;
       }

       //Name Warnings
       nameTooShortWarning = GameObject.Find("NameTooShortWarning").GetComponent<TextMeshProUGUI>();

       nameTooLongWarning = GameObject.Find("NameTooLongWarning").GetComponent<TextMeshProUGUI>();
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
      Debug.Log("nameLength = " + nameLength + "." );
      SceneManager.LoadScene("Level");
    }
}
