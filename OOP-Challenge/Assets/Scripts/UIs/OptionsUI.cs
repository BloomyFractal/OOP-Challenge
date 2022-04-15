using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsUI : MonoBehaviour
{
  //Arrow variables
  private Transform navArrow;
  private Vector3 arrowMovePanels = new Vector3(0,10,0);

  //Positions close to Options text and buttons
  private Vector3 arrowFacesDiff = new Vector3(8,6,0);
  private Vector3 arrowFacesBack = new Vector3(8,-4,0);

  //Arrow positions within Difficulty Panel
  private Vector3 arrowFacesEasy = new Vector3(1.3f,5,0);
  private Vector3 arrowFacesNormal = new Vector3(1.3f,4,0);
  private Vector3 arrowFacesHard = new Vector3(1.3f,3,0);

  private Vector3 arrowMoveDifficulties = new Vector3(0,1,0);

  //Script Communication
  private DataPersists dataPersists;

    void Start()
    {
    //Arrow's default position
     navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
     navArrow.position = arrowFacesDiff;
     Debug.Log("navArrow.position = " + navArrow.position + ".");
     Debug.Log("arrowFacesDiff = " + arrowFacesDiff + ".");

     //Data
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();

     //Checking that I do have access to the difficulty variable
     Debug.Log("difficulty = " + dataPersists.difficulty + ".");
    }

    void Update()
    {
     // ABSTRACTION
     ArrowFunctions();
    }

    private void ArrowFunctions()
    {
     //Choose between panels and back
     //Downward
     if (navArrow.position == arrowFacesDiff && Input.GetKeyDown(KeyCode.DownArrow))
     {
       navArrow.position -= arrowMovePanels;
     }

     //Upward
     if (navArrow.position == arrowFacesBack && Input.GetKeyDown(KeyCode.UpArrow))
     {
       navArrow.position += arrowMovePanels;
     }

     //Returning to TitleScreen
     if (navArrow.position == arrowFacesBack && Input.GetKeyDown(KeyCode.Return))
     {
       SceneManager.LoadScene("TitleScreen");
     }

     //Enter Difficulty Panel
     if (navArrow.position == arrowFacesDiff && Input.GetKeyDown(KeyCode.Return))
     {
       navArrow.position = arrowFacesNormal;
     }

     //Navigate within Difficulty Panel
     //Go upward
     if (navArrow.position.x == arrowFacesNormal.x && navArrow.position.y < arrowFacesEasy.y + 0.1f && Input.GetKeyDown(KeyCode.UpArrow))
     {
      navArrow.position += arrowMoveDifficulties;
      Debug.Log("navArrow.position = " + navArrow.position + ".");
     }

     //Go downward
     if (navArrow.position.x == arrowFacesNormal.x && navArrow.position.y > arrowFacesHard.y - 0.1f && Input.GetKeyDown(KeyCode.DownArrow))
     {
      navArrow.position -= arrowMoveDifficulties;
      Debug.Log("navArrow.position = " + navArrow.position + ".");
     }

     //Amount of vertical space between any two given buttons
     float verticalButtonGap = Mathf.Abs(arrowFacesEasy.y - arrowFacesNormal.y);

     //Change difficulty if Return is pressed around 10% of the button's Y coor.
     if (navArrow.position.y < arrowFacesEasy.y + (verticalButtonGap * 0.10f) && navArrow.position.y > arrowFacesEasy.y - (verticalButtonGap * 0.10f) && Input.GetKeyDown(KeyCode.Return))
     {
      dataPersists.difficulty = 0.5f;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
     }

     else if ((navArrow.position.y < arrowFacesNormal.y + (verticalButtonGap * 0.10f) && navArrow.position.y > arrowFacesNormal.y - (verticalButtonGap * 0.10f) && Input.GetKeyDown(KeyCode.Return)))
     {
      dataPersists.difficulty = 1;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
     }

     else if ((navArrow.position.y < arrowFacesHard.y + (verticalButtonGap * 0.10f) && navArrow.position.y > arrowFacesHard.y - (verticalButtonGap * 0.10f) && Input.GetKeyDown(KeyCode.Return)))
     {
      dataPersists.difficulty = 2;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
     }

     //Return to Panel Choice
     //From Easy modo
     if (navArrow.position.y < arrowFacesEasy.y + (verticalButtonGap * 0.10f) && navArrow.position.y > arrowFacesEasy.y - (verticalButtonGap * 0.10f) && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
     {
       navArrow.position = arrowFacesDiff;
     }

     //From Normal mode
     if (navArrow.position.y < arrowFacesNormal.y + (verticalButtonGap * 0.10f) && navArrow.position.y > arrowFacesNormal.y - (verticalButtonGap * 0.10f) && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
     {
       navArrow.position = arrowFacesDiff;
     }

     //From Hard mode
     if (navArrow.position.y < arrowFacesHard.y + (verticalButtonGap * 0.10f) && navArrow.position.y > arrowFacesHard.y - (verticalButtonGap * 0.10f) && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
     {
       navArrow.position = arrowFacesDiff;
     }
    }

    //Click functions
    //Set Easy modo
    public void EasyModo()
    {
      dataPersists.difficulty = 0.5f;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
    }

    //Set Normal Mode
    public void NormalMode()
    {
      dataPersists.difficulty = 1;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
    }

    //Set Hard Mode
    public void HardMode()
    {
      dataPersists.difficulty = 1.5f;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
    }

    //Back to Title Screen
    public void TitleScreen()
    {
      SceneManager.LoadScene("TitleScreen");
    }
}
