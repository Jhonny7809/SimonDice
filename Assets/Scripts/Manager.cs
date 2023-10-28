using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public SpriteRenderer[] figures;
    public SpriteRenderer[] figCirc;

    private int figureSelect;

    public float stayLit;
    private float stayLitCounter;

    public float waitLight;
    private float waitCounter;

    private bool lit;
    private bool dark;

    public List<int> sequence;
    private int sequencePosition;

    public bool gameActive = false;
    private int inputSequence;

    //xd
    public TextMeshProUGUI scoretxt;
    int score;

    int vidas;
    public GameObject[] vidasxd;

    public GameObject retry;

    public Animator scoreAnim;

    private void Start()
    {
        vidas = 3;
        StartGame();  
    }

    private void Update()
    {
        if (lit)
        {
            stayLitCounter -= Time.deltaTime;

            if (stayLitCounter < 0)
            {
                figures[sequence[sequencePosition]].color = Color.gray;
                lit = false;
                
                dark = true;
                waitCounter = waitLight;

                sequencePosition++;
            }
        }

        if (dark)
        {
            waitCounter -= Time.deltaTime;

            if(sequencePosition >= sequence.Count)
            {
                dark = false;
                gameActive = true;
            }
            else if (waitCounter < 0)
            {
                figureSelect = Random.Range(0, figures.Length);
                
                figures[sequence[sequencePosition]].color = Color.white;
                //aqui van las anuimaciones xd
                figures[sequence[sequencePosition]].GetComponent<AudioSource>().Play();
                figures[sequence[sequencePosition]].GetComponent<Animator>().SetTrigger("1");
                stayLitCounter = stayLit;
                lit = true;
                dark = false;
            }
        }
    }

    public void StartGame()
    {
        sequence.Clear();

        sequencePosition = 0;
        inputSequence = 0;

        figureSelect = Random.Range(0, figures.Length);

        sequence.Add(figureSelect);

        figures[sequence[sequencePosition]].color = Color.white;
        figures[sequence[sequencePosition]].GetComponent<AudioSource>().Play();
        figures[sequence[sequencePosition]].GetComponent<Animator>().SetTrigger("1");
        //aqui van las animaciones xd
        stayLitCounter = stayLit;
        lit = true;

        
        score = 0;
        scoretxt.text = score.ToString();

        gameActive = true;
    }

    public void FigurePressed(int id)
    {
        if(gameActive)
        {
            if (sequence[inputSequence] == id)
            {
                Debug.Log("correct");

                inputSequence++;

                if (inputSequence >= sequence.Count)
                {

                    gameActive = false;
                    score++;
                    scoretxt.text = score.ToString();
                    scoreAnim.SetTrigger("2");
                    Invoke("nextsecuence", 1f);
                   
                }
            }
            else
            {
                Debug.Log("wrong");
                gameActive = false;
                vidas--;
                switch (vidas)
                {
                    case 3:                        
                        break;
                    case 2:
                        vidasxd[2].SetActive(false);
                        score = 0;
                        scoretxt.text = score.ToString();
                        scoreAnim.SetTrigger("1");
                        Invoke("StartGame", 1.5f);
                        //gameActive = true;
                        break;
                    case 1:
                        vidasxd[1].SetActive(false);
                        score = 0;
                        scoretxt.text = score.ToString();
                        scoreAnim.SetTrigger("1");
                        Invoke("StartGame", 1.5f);
                        //gameActive = true;
                        break;
                    case 0:
                        vidasxd[0].SetActive(false);
                        score = 0;
                        scoretxt.text = score.ToString();
                        scoreAnim.SetTrigger("1");
                        gameActive = false;
                        retry.SetActive(true);
                        break;

                }
                //gameActive = false;
            }
        }
    }

    public void nextsecuence()
    {
        sequencePosition = 0;
        inputSequence = 0;

        figureSelect = Random.Range(0, figures.Length);

        sequence.Add(figureSelect);

        figures[sequence[sequencePosition]].color = Color.white;
        figures[sequence[sequencePosition]].GetComponent<AudioSource>().Play();
        figures[sequence[sequencePosition]].GetComponent<Animator>().SetTrigger("1");
        //aqui van las anuimaciones xd
        stayLitCounter = stayLit;
        lit = true;

        //gameActive = false;
    }
}
