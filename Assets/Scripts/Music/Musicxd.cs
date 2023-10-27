using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicxd : MonoBehaviour
{
    public GameObject[] singlexd;
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        singlexd = GameObject.FindGameObjectsWithTag("musicasingle");
        if(singlexd.Length > 1)
        {
            Destroy(singlexd[1]);
        }
    }
}
