using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
  //Arrow variables
  public Transform navArrow;

  private Vector3 arrowFacesStart = new Vector3(1.1f,2f,0);
  private Vector3 arrowFacesHowToPlay = new Vector3(1f,1.3f,0);
  private Vector3 arrowFacesOptions = new Vector3(1f,0.6f,0);
  private Vector3 arrowFacesQuit = new Vector3(1f,-0.1f,0);

  private Vector3 arrowMove = new Vector3(0,0.7f,0);

  //Title Screen Buttons
  public GameObject start;
  public GameObject howToPlay;
  public GameObject options;
  public GameObject quit;

    void Start()
    {
     navArrow.position = arrowFacesStart;
    }

    void Update()
    {
     ArrowFunctions();
    }

    private void ArrowFunctions()
    {
     //Go downward
     if (navArrow.position.y != arrowFacesQuit.y && Input.GetKeyDown(KeyCode.DownArrow))
     {
       navArrow.position -= arrowMove;
     }

    }
}
