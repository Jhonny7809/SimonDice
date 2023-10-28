using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeanim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LifeDeath()
    {
        StartCoroutine("VdaPerdida");
    }

    IEnumerator VidaPerdida()
    {
        gameObject.GetComponent<Animator>().SetTrigger("a");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        StopAllCoroutines();
    }
}
