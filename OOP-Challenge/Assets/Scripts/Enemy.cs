using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  //Enemy variables
  public Transform enemyTrans;
  public float xSpeed;
  public float ySpeed;

  //Hero variables
  public Transform heroTrans;

  //Behavior variables
  public float yDist;

  //Script communication
  public Hero hero;
  public GameInfo gameInfo;

    void Start()
    {

    }

    void Update()
    {

    }

    public void defineDist()
    {
     yDist = heroTrans.position.y - enemyTrans.position.y;
    }

    public virtual void Move()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
      //Defeat enemy by jumping on it and gain score
      if (collision.gameObject.tag == "Hero" && yDist > 0.1f && hero.isJumping && enemyTrans.localScale.y > 0.3f)
      {
        StartCoroutine(removeEnemy());
        gameInfo.score += 1000;

        gameObject.tag = "DeadEnemy";
        Debug.Log("gameObject.tag = " + gameObject.tag + ".");

        if (gameObject.tag == "DeadEnemy")
        {
         xSpeed = 0;
         ySpeed = 0;

         Debug.Log("xSpeed = " + xSpeed + ".");
         Debug.Log("ySpeed = " + ySpeed + ".");
        }

        //Make enemy smaller once jumped on
        Vector3 scaleChange = new Vector3(0,0.2f,0);
        enemyTrans.localScale -= scaleChange;
        Debug.Log("enemyTrans.localScale = " + enemyTrans.localScale + ".");

        //Make hero bounce on enemy
        hero.heroRb.AddForce(Vector3.up * hero.jumpForce/2,ForceMode.Impulse);
      }
    }

    IEnumerator removeEnemy()
    {
      yield return new WaitForSeconds(3);
      gameObject.SetActive(false);
    }
}
