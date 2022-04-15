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

  //Tutorial variables
  public GameObject step1;
  public GameObject step2;
  public GameObject step3;
  public GameObject step4;

  //Button variables
  //Foward buttons
  public GameObject from1To2;
  public GameObject from2To3;
  public GameObject from3To4;

  //Backward buttons
  public GameObject from2To1;
  public GameObject from3To2;
  public GameObject from4To3;

    void Start()
    {
      navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
      navArrow.position = arrowFacesNext;
    }

    void Update()
    {
     // ABSTRACTION
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

     //From Step 1 to Step 2
     if (step1.activeInHierarchy && navArrow.position == arrowFacesNext &&  Input.GetKeyDown(KeyCode.Return))
     {
       navArrow.position = arrowFacesBack;
       step1.SetActive(false);
       step2.SetActive(true);

       //Switch right hand buttons
       from1To2.SetActive(false);
       from2To3.SetActive(true);

       //Switch left hand buttons
       from2To1.SetActive(true);
     }

     //From Step 2 to Step 1
     if (step2.activeInHierarchy && navArrow.position == arrowFacesPrevious &&  Input.GetKeyDown(KeyCode.Return))
     {
       navArrow.position = arrowFacesBack;
       step1.SetActive(true);
       step2.SetActive(false);

       //Switch right hand buttons
       from1To2.SetActive(true);
       from2To3.SetActive(false);

       //Switch left hand buttons
       from2To1.SetActive(false);
     }

     //From Step 2 to Step 3
     if (step2.activeInHierarchy && navArrow.position == arrowFacesNext &&  Input.GetKeyDown(KeyCode.Return))
     {
       navArrow.position = arrowFacesBack;
       step2.SetActive(false);
       step3.SetActive(true);

       //Switch right hand buttons
       from2To3.SetActive(false);
       from3To4.SetActive(true);

       //Switch left hand buttons
       from2To1.SetActive(false);
       from3To2.SetActive(true);
     }

     //From Step 3 to Step 2
     if (step3.activeInHierarchy && navArrow.position == arrowFacesPrevious &&  Input.GetKeyDown(KeyCode.Return))
     {
       navArrow.position = arrowFacesBack;
       step2.SetActive(true);
       step3.SetActive(false);

       //Switch right hand buttons
       from3To4.SetActive(false);
       from2To3.SetActive(true);

       //Switch left hand buttons
       from2To1.SetActive(true);
       from3To2.SetActive(false);
     }

     //From Step 3 to Step 4
     if (step3.activeInHierarchy && navArrow.position == arrowFacesNext &&  Input.GetKeyDown(KeyCode.Return))
     {
       navArrow.position = arrowFacesBack;
       step3.SetActive(false);
       step4.SetActive(true);

       //Switch right hand buttons
       from3To4.SetActive(false);

       //Switch left hand buttons
       from3To2.SetActive(false);
       from4To3.SetActive(true);
     }

     //From Step 4 to Step 3
     if (step4.activeInHierarchy && navArrow.position == arrowFacesPrevious &&  Input.GetKeyDown(KeyCode.Return))
     {
       navArrow.position = arrowFacesBack;
       step3.SetActive(true);
       step4.SetActive(false);

       //Switch right hand buttons
       from3To4.SetActive(true);

       //Switch left hand buttons
       from3To2.SetActive(true);
       from4To3.SetActive(false);
     }
    }

    //Click functions
    //Return to Title Screen
    public void TitleScreen()
    {
     SceneManager.LoadScene("TitleScreen");
    }

    //Tutorial Navigation
    //Foward clicks
    public void From1To2()
    {
      //From Step 1 to Step 2
      if (step1.activeInHierarchy)
      {
        //Switch panels
        step1.SetActive(false);
        step2.SetActive(true);

        //Switch right hand buttons
        from1To2.SetActive(false);
        from2To3.SetActive(true);

        //Switch left hand buttons
        from2To1.SetActive(true);
      }
    }

    public void From2To3()
    {
      //From Step 2 to Step 3
      if (step2.activeInHierarchy)
      {
        //Switch panels
        step2.SetActive(false);
        step3.SetActive(true);

        //Switch right hand buttons
        from2To3.SetActive(false);
        from3To4.SetActive(true);

        //Switch left hand buttons
        from2To1.SetActive(false);
        from3To2.SetActive(true);
      }
    }

    public void From3To4()
    {
      //From Step 3 to Step 4
      if (step3.activeInHierarchy)
      {
        //Switch panels
        step3.SetActive(false);
        step4.SetActive(true);

        //Switch right hand buttons
        from3To4.SetActive(false);

        //Switch left hand buttons
        from3To2.SetActive(false);
        from4To3.SetActive(true);
      }
    }

    //Backward clicks
    public void From4To3()
    {
      //From Step 4 to Step 3
      if (step4.activeInHierarchy)
      {
        //Switch panels
        step3.SetActive(true);
        step4.SetActive(false);

        //Switch right hand buttons
        from3To4.SetActive(true);

        //Switch left hand buttons
        from3To2.SetActive(true);
        from4To3.SetActive(false);
      }
    }

    public void From3To2()
    {
      //From Step 3 to Step 2
      if (step3.activeInHierarchy)
      {
        //Switch panels
        step2.SetActive(true);
        step3.SetActive(false);

        //Switch right hand buttons
        from3To4.SetActive(false);
        from2To3.SetActive(true);

        //Switch left hand buttons
        from2To1.SetActive(true);
        from3To2.SetActive(false);
      }
    }

    public void From2To1()
    {
      //From Step 2 to Step 1
      if (step2.activeInHierarchy)
      {
        //Switch panels
        step1.SetActive(true);
        step2.SetActive(false);

        //Switch right hand buttons
        from1To2.SetActive(true);
        from2To3.SetActive(false);

        //Switch left hand buttons
        from2To1.SetActive(false);
      }
    }
}
