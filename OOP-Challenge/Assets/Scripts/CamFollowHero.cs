using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowHero : MonoBehaviour
{
  private Transform heroTrans;

    void Start()
    {
     heroTrans = GameObject.Find("Hero").GetComponent<Transform>();
    }

    void LateUpdate()
    {
     camFollowHero();
    }

    private void camFollowHero()
    {
     Vector3 offset = new Vector3 (-10,10,20);
     Vector3 heroPos = new Vector3 (heroTrans.position.x,heroTrans.position.y,heroTrans.position.z);

     transform.position = heroPos + offset;
    }
}
