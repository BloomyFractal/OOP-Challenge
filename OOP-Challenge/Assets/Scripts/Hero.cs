using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
  //Activate axis
  private float horiInput;

  //Hero variables
  private Rigidbody heroRb;
  private int speed = 10;
  private int jumpForce = 200;
  private bool isJumping;

    void Start()
    {
      heroRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
     Move();
    }

    private void Move()
    {
     //Horizontal movement
     horiInput = Input.GetAxis("Horizontal");

     transform.Translate(Vector3.left * speed * horiInput * Time.deltaTime);

     //Make player jump only when on the ground
     if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
     {
       heroRb.AddForce(Vector3.up * jumpForce * Time.deltaTime,ForceMode.Impulse);

       isJumping = true;
       Debug.Log("isJumping = " + isJumping + ".");
     }
    }

    //Check if player is touching ground
    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag == "Ground")
      {
        isJumping = false;
        Debug.Log("isJumping = " + isJumping + ".");
      }
    }
}
