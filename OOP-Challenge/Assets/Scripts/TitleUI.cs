using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleUI : MonoBehaviour
{
  //Arrow variables
  private Transform navArrow;
  private Vector3 arrowMove = new Vector3(0,0.7f,0);

  //Positions close to Title buttons
  private Vector3 arrowFacesStart = new Vector3(1.1f,2f,0);
  private Vector3 arrowFacesHowToPlay = new Vector3(1.1f,1.3f,0);
  private Vector3 arrowFacesOptions = new Vector3(1.1f,0.6f,0);
  private Vector3 arrowFacesQuit = new Vector3(1.1f,-0.1f,0);

    void Start()
    {
     navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
     navArrow.position = arrowFacesStart;
    }

    void Update()
    {
     ArrowFunctions();
    }

    private void ArrowFunctions()
    {
     //Go downward
     if (navArrow.position.y > arrowFacesQuit.y && Input.GetKeyDown(KeyCode.DownArrow))
     {
       navArrow.position -= arrowMove;
       Debug.Log("navArrow.position = " + navArrow.position + ".");
     }

     //Go upward
     if (navArrow.position.y < arrowFacesStart.y && Input.GetKeyDown(KeyCode.UpArrow))
     {
       navArrow.position += arrowMove;
       Debug.Log("navArrow.position = " + navArrow.position + ".");
     }

     //Go to Name Scene
     if (navArrow.position.y == arrowFacesStart.y && Input.GetKeyDown(KeyCode.Return))
     {
       SceneManager.LoadScene("EnterName");
     }

     //Go to How To Play Scene
     if (navArrow.position.y == arrowFacesHowToPlay.y && Input.GetKeyDown(KeyCode.Return))
     {
       SceneManager.LoadScene("HowToPlayTest");
     }

     //Go to Options Scene
     if ((navArrow.position.y <= arrowFacesOptions.y + 0.1 && Input.GetKeyDown(KeyCode.Return)) || (navArrow.position.y >= arrowFacesOptions.y - 0.1 && Input.GetKeyDown(KeyCode.Return)))
     {
       SceneManager.LoadScene("Options");
     }

     //Quit game
     if ((navArrow.position.y <= arrowFacesQuit.y + 0.1 && Input.GetKeyDown(KeyCode.Return)) || (navArrow.position.y >= arrowFacesQuit.y - 0.1 && Input.GetKeyDown(KeyCode.Return)))
     {
       #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
       #else
        Application.Quit();
       #endif
     }
    }

    //Click Functions
    //Start
    public void GoToEnterScene()
    {
      SceneManager.LoadScene("EnterName");
    }

    //Quit
    public void ExitGame()
    {
      #if UNITY_EDITOR
       EditorApplication.ExitPlaymode();
      #else
       Application.Quit();
      #endif
    }
}
