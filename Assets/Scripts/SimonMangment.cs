using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonMangment : MonoBehaviour
{
    [SerializeField] public List<int> secuencia = new List<int>();
    public GameObject[] butons;
    int index=1;
    int wBut;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i <= 200; i++)
        {
            secuencia.Add(Random.Range(0, 4));
        }
        //StartCoroutine("countSec");
    }

    // Update is called once per frame
    void Update()
    {
        //if (secuencia.Count < 200)


        StartCount();
    }

    public void colorButRed(GameObject but)
    {
        but.GetComponent<Image>().color = Color.red;
    }

    public void colorButWhite(GameObject but)
    {
        but.GetComponent<Image>().color = Color.white;
    }
    public void StartCount()
    {
        StartCoroutine(countSec());

    }
    public IEnumerator countSec()
    {
        foreach(int i in secuencia)
        {
            Debug.Log(i);
        }
        yield return new WaitForSeconds(5.0f);
    }
}
