using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OptionsUI : MonoBehaviour
{
  //Arrow variables
  private Transform navArrow;
  private Vector3 arrowMovePanels = new Vector3(0,10,0);

  //Positions close to Options text and buttons
  private Vector3 arrowFacesDiff = new Vector3(8,6,0);
  private Vector3 arrowFacesBack = new Vector3(8,-4,0);

  //Arrow positions within Difficulty Panel
  private Vector3 arrowFacesEasy = new Vector3(1,5,0);
  private Vector3 arrowFacesNormal = new Vector3(1,4,0);
  private Vector3 arrowFacesHard = new Vector3(1,3,0);

  private Vector3 arrowMoveDifficulties = new Vector3(0,1,0);

  //Script Communication
  private DataPersists dataPersists;

    void Start()
    {
    //Arrow
     navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
     navArrow.position = arrowFacesDiff;

     //Data
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();

     //Checking that I do have access to the difficulty variable
     Debug.Log("difficulty = " + dataPersists.difficulty + ".");
    }

    void Update()
    {
     ArrowFunctions();
    }

    private void ArrowFunctions()
    {
     //Choose between panels and back
     if (navArrow.position == arrowFacesDiff && Input.GetKeyDown(KeyCode.DownArrow))
     {
       navArrow.position -= arrowMovePanels;
     }

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

     //In the game, the Easy button is highest, Normal is in between and Hard is lowest.

     //Navigate within Difficulty Panel
     //Go upward
     if (navArrow.position.x != arrowFacesDiff.x && navArrow.position.y < arrowFacesEasy.y - 0.1f && Input.GetKeyDown(KeyCode.UpArrow))
     {
      navArrow.position += arrowMoveDifficulties;
      Debug.Log("navArrow.position = " + navArrow.position + ".");
     }

     //Go downward
     if (navArrow.position.x != arrowFacesDiff.x && navArrow.position.y > arrowFacesHard.y + 0.1f && Input.GetKeyDown(KeyCode.DownArrow))
     {
      navArrow.position -= arrowMoveDifficulties;
      Debug.Log("navArrow.position = " + navArrow.position + ".");
     }

     // ↓ PROBLEM HERE ↓

     //Change difficulty
     if (navArrow.position.y == arrowFacesEasy.y && Input.GetKeyDown(KeyCode.Return))
     {
      dataPersists.difficulty = 0.5f;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
     }

     else if (navArrow.position.y == arrowFacesNormal.y && Input.GetKeyDown(KeyCode.Return))
     {
      dataPersists.difficulty = 1;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
     }

     else if (navArrow.position.y == arrowFacesHard.y && Input.GetKeyDown(KeyCode.Return))
     {
      dataPersists.difficulty = 1.5f;
      Debug.Log("difficulty = " + dataPersists.difficulty + ".");
     }
    }
}
