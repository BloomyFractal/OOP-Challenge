using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayUI : MonoBehaviour
{
  //Arrow variables
  private Transform navArrow;

  //Positions close  to buttons
  private Vector3 arrowFacesBack = new Vector3(-9,-4.4f,0);
  private Vector3 arrowFacesPrevious = new Vector3(-3.5f,-3.5f,0);
  private Vector3 arrowFacesNext = new Vector3(0.7f,-3.5f,0);

    void Start()
    {
      navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
      navArrow.position = arrowFacesNext;
    }

    void Update()
    {
     ArrowFunctions();
    }

    private void ArrowFunctions()
    {
     //Choose between Previous and Next
     if (navArrow.position == arrowFacesPrevious && Input.GetKeyDown(KeyCode.RightArrow))
     {
       navArrow.position = arrowFacesNext;
     }

     if (navArrow.position == arrowFacesNext && Input.GetKeyDown(KeyCode.LeftArrow))
     {
       navArrow.position = arrowFacesPrevious;
     }

     //Go to Back Button
     if (navArrow.position == arrowFacesPrevious && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.DownArrow))
     {
       navArrow.position = arrowFacesBack;
     }

     if (navArrow.position == arrowFacesNext && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
     {
       navArrow.position = arrowFacesBack;
     }

     //Go from Back to Previous Page
     if (navArrow.position == arrowFacesBack && Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
     {
       navArrow.position = arrowFacesPrevious;
     }

     //Return to Title Screen
     if (navArrow.position == arrowFacesBack && Input.GetKeyDown(KeyCode.Return))
     {
       SceneManager.LoadScene("TitleScreen");
     }
    }

    //Click functions
    //Return to Title Screen
    public void TitleScreen()
    {
     SceneManager.LoadScene("TitleScreen");  
    }
}
