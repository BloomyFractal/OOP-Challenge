using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  private float speed;

    void Start()
    {
     speed = 5;
    }

    void Update()
    {
     Shoot();
    }

    private void Shoot()
    {
     transform.Translate(Vector3.right * speed * Time.deltaTime);
     StartCoroutine(removeEnemy());
    }

    IEnumerator removeEnemy()
    {
      yield return new WaitForSeconds(6);
      Destroy(gameObject);
    }
}
