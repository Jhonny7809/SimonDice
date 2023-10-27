using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuscrip : MonoBehaviour
{
    public Animator[] figs;
    int fig;
    int wichxd;
    void Start()
    {
        InvokeRepeating("animasao", 1f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animasao()
    {
        fig = Random.Range(0, 4);
        wichxd = Random.Range(1, 3);
        if (wichxd == 1)
            figs[fig].SetTrigger("1");
        if (wichxd == 2)
            figs[fig].SetTrigger("2");
        //yield return new WaitForSeconds(2f);
    }
}
