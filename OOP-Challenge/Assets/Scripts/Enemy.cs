using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  //Enemy variables
  public Transform enemyTrans;

  //Hero variables
  public Transform heroTrans;

  //Behavior variables
  public float yDist;

  //Script communication
  public Hero hero;
  private GameInfo gameInfo;

    void Start()
    {
     gameInfo = GameObject.Find("Canvas").GetComponent<GameInfo>();
    }

    void Update()
    {

    }

    public virtual void showDist()
    {
     yDist = heroTrans.position.y - enemyTrans.position.y;
     Debug.Log("yDist = " + yDist + ".");
    }

    private void OnCollisionEnter(Collision collision)
    {
      Debug.Log("yDIST IS " + yDist + ".");
      Debug.Log("collision.gameObject.tag IS " + collision.gameObject.tag + ".");
      Debug.Log("hero.isJumping IS " + hero.isJumping + ".");

      //Defeat enemy by jumping on it and gain score
      if (collision.gameObject.tag == "Hero" && yDist > 0.1f && hero.isJumping)
      {
        StartCoroutine(removeEnemy());
        Debug.Log("The enemy shall be destroyed.");
        gameInfo.score += 1000;
      }
    }

    IEnumerator removeEnemy()
    {
      yield return new WaitForSeconds(3);
      gameObject.SetActive(false);
    }
}
