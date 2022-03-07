using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsUI : MonoBehaviour
{
  //Arrow variables
  private Transform navArrow;
  private Vector3 arrowMove = new Vector3(0,0.7f,0);

  //Positions close to Options text and buttons
  private Vector3 arrowFacesDiff = new Vector3(0,5,0);

    void Start()
    {
     navArrow = GameObject.Find("NavigationArrow").GetComponent<Transform>();
     navArrow.position = arrowFacesDiff;
    }

    void Update()
    {

    }
}
