using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersists : MonoBehaviour
{
  //Reference for other scripts
  public DataPersists dataPersists;

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
