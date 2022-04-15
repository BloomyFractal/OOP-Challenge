using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE

public class GroundEnemy : Enemy
{
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
     transform.Translate(Vector3.left * xSpeed * dataPersists.difficulty * Time.deltaTime);
    }
}
