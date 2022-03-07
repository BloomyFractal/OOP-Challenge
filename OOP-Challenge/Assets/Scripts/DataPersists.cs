using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersists : MonoBehaviour
{
  public static DataPersists dataPersists;

  public float difficulty;

    //Singleton
    private void Awake()
    {

     if (dataPersists != null)
      {
        Destroy(gameObject);
        return;
      }

      dataPersists = this;
      DontDestroyOnLoad(gameObject);

    }

    void Start()
    {

    }

    void Update()
    {

    }
}
