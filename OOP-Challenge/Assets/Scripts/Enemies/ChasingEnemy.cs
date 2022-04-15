using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE

public class ChasingEnemy : Enemy
{
  //Script communication
  private DataPersists dataPersists;

    void Start()
    {
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();
    }

    void Update()
    {
     defineDist();
     Move();
    }

    // POLYMORPHISM
    public override void Move()
    {
     //Rotate toward hero
     if (gameObject.tag == "Enemy")
     {
       transform.LookAt(heroTrans);
     }

     //Define current position
     Vector3 chasingPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);

     //Define target position
     Vector3 heroPos = new Vector3 (heroTrans.position.x,heroTrans.position.y,transform.position.z);

     //Define path
     Vector3 goToHero = Vector3.MoveTowards(transform.position,heroPos,xSpeed * dataPersists.difficulty * Time.deltaTime);

     //Fly toward hero without leaving the level path
     if (gameObject.tag == "Enemy")
     {
       transform.position = goToHero;
     }
    }
}
