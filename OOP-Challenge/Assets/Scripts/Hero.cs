using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
  //Activate axis
  private float horiInput;

  //Hero variables
  private Rigidbody heroRb;
  private int speed = 400;
  private int jumpForce = 500;
  public bool isJumping;

  //Life variables
  private GameObject[] lives;
  private Vector3 lifePos;
  private int i;
  public int lifeNum;

  //Script communication
  private GameInfo gameInfo;

    void Start()
    {
     lifeNum = 5;
     lives = GameObject.FindGameObjectsWithTag("Life");

     heroRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
     Move();
     Lives();
    }

    private void Move()
    {
     //Horizontal movement
     horiInput = Input.GetAxis("Horizontal");

     heroRb.AddForce(Vector3.left * speed * horiInput * Time.deltaTime);

     //Make player jump only when on the ground
     if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
     {
       heroRb.AddForce(Vector3.up * jumpForce * Time.deltaTime,ForceMode.Impulse);

       isJumping = true;
       Debug.Log("isJumping = " + isJumping + ".");
     }
    }

    private void Lives()
    {
     //Display lives below player's name
     for (i = 0; i < lifeNum; i++)
     {
       lifePos = new Vector3 (-4 - 2 * i,18,0);
       lives[i].transform.position = lifePos;
     }
    }

    //Check if player is touching ground
    public void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag == "Ground")
      {
        isJumping = false;
        Debug.Log("isJumping = " + isJumping + ".");
      }

      //Hero loses a life if it touches an enemy without being above it
      if (collision.gameObject.tag == "Enemy" && lifeNum > 0 && !isJumping)
      {
       lives[i-1].gameObject.SetActive(false);
       lifeNum--;
       Debug.Log("lifeNum = " + lifeNum + ".");
      }
    }
}
