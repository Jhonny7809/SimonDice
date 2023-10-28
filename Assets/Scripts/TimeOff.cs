using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOff : MonoBehaviour
{
    public GameObject gamexd;
    void Start()
    {
        Invoke("AbreteSesamo", 1f);
    }

    public void AbreteSesamo()
    {
        gamexd.GetComponent<Manager>().enabled = true;
    }
}
