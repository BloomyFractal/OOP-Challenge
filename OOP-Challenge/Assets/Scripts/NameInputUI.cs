using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameInputUI : MonoBehaviour
{
  //Arrow variables
  private Transform navArrow;

  //Positions
  private Vector3 arrowFacesSubmit = new Vector3(1.2f,1,0);
  private Vector3 arrowFacesBack = new Vector3(4.4f,-1.7f,0);

  //Script communication
  private DataPersists dataPersists;

    void Start()
    {
     //Arrow
     navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
     navArrow.position = arrowFacesSubmit;

     //Data
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();
    }


    void Update()
    {
     ArrowFunctions();
    }

    public void ArrowFunctions()
    {
     //Navigate between Submit and Back
     if (navArrow.position == arrowFacesSubmit && Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
     {
       navArrow.position = arrowFacesBack;
     }

     if (navArrow.position == arrowFacesBack && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
     {
       navArrow.position = arrowFacesSubmit;
     }

     //Return to Title Screen
     if (navArrow.position == arrowFacesBack && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
     {
       SceneManager.LoadScene("TitleScreen");
     }

     //Register Name and Go to Level Scene
     if (navArrow.position == arrowFacesSubmit && Input.GetKeyDown(KeyCode.Return))
     {
      dataPersists.SetPlayerName();
     }
    }

    //Click Functions

    //Back to Title Screen
    public void TitleScreen()
    {
     SceneManager.LoadScene("TitleScreen");
    }

    //Register Name and Go to Level Scene
    public void LevelScene()
    {
     dataPersists.SetPlayerName();
    }
}
