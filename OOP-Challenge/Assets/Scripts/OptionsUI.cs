using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsUI : MonoBehaviour
{
  //Arrow variables
  private Transform navArrow;
  private Vector3 arrowMovePanels = new Vector3(0,10f,0);

  //Positions close to Options text and buttons
  private Vector3 arrowFacesDiff = new Vector3(8,6,0);
  private Vector3 arrowFacesBack = new Vector3(8,-4,0);

    void Start()
    {
     navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
     navArrow.position = arrowFacesDiff;
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
    }
}
