using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class DataPersists : MonoBehaviour
{
  // ENCAPSULATION
  public DataPersists dataPersists { get; private set; }

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
  public float highScoreNum;//The one saved in JSON

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

       //Name Warnings
       nameTooShortWarning = GameObject.Find("NameTooShortWarning").GetComponent<TextMeshProUGUI>();

       nameTooLongWarning = GameObject.Find("NameTooLongWarning").GetComponent<TextMeshProUGUI>();

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
      }
    }

    //Data persistence between scenes
    public void SetPlayerName()
    {
      playerName = inputField.text;
      Debug.Log("playerName = " + playerName + "." );
      SceneManager.LoadScene("Level");
    }

    //Data persistence between sessions
    [System.Serializable]
    class SaveData
    {
     public float highScoreNum;
     public string highScorePlayer;
    }

    public void SaveNameAndScore()
    {
      SaveData data = new SaveData();
      data.highScoreNum = highScoreNum;
      data.highScorePlayer = playerName;

      string json = JsonUtility.ToJson(data);

      File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadNameAndScore()
    {
      string path = Application.persistentDataPath + "/savefile.json";
      if (File.Exists(path))
      {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        highScoreNum = data.highScoreNum;
        highScorePlayer = data.highScorePlayer;
      }
    }
}
