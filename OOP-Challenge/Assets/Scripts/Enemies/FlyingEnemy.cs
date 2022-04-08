using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
  //Projectile variables
  private float repeatRate = 2;
  public GameObject projPrefab;

  //Script communication
  private DataPersists dataPersists;

    void Start()
    {
     dataPersists = GameObject.Find("Data").GetComponent<DataPersists>();

     InvokeRepeating("summonProjectile",1,repeatRate);
    }

    void Update()
    {
     defineDist();
     Move();
    }

    public override void Move()
    {
     //X axis movement
     transform.Translate(Vector3.right * xSpeed * dataPersists.difficulty * Time.deltaTime);

     //Y axis movement
     transform.Translate(Vector3.up * ySpeed * Mathf.Sin(Time.time * 1.5f) * Time.deltaTime);

     //Stop shooting if enemy is defeated
     if (gameObject.tag == "DeadEnemy")
     {
       CancelInvoke();
     }
    }

    private void summonProjectile()
    {
     Instantiate(projPrefab,transform.position,projPrefab.transform.rotation);
    }
}
