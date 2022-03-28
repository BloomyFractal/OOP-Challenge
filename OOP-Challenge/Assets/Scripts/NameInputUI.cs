using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameInputUI : MonoBehaviour
{
  //Arrow variables
  private Transform navArrow;

  //Positions
  private Vector3 arrowFacesSubmit = new Vector3(1.2f,1,0);
  private Vector3 arrowFacesBack = new Vector3(4.4f,-1.7f,0);



    void Start()
    {
     navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
     navArrow.position = arrowFacesSubmit;
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

    }
}
