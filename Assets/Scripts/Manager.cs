using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public SpriteRenderer[] figures;

    private int figureSelect;

    public float stayLit;
    private float stayLitCounter;

    public float waitLight;
    private float waitCounter;

    private bool lit;
    private bool dark;

    public List<int> sequence;
    private int sequencePosition;

    private bool gameActive = false;
    private int inputSequence;

    private void Start()
    {
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

        stayLitCounter = stayLit;
        lit = true;
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
                    sequencePosition = 0;
                    inputSequence = 0;
                    
                    figureSelect = Random.Range(0, figures.Length);

                    sequence.Add(figureSelect);

                    figures[sequence[sequencePosition]].color = Color.white;

                    stayLitCounter = stayLit;
                    lit = true;

                    gameActive = false;
                }
            }
            else
            {
                Debug.Log("wrong");
                gameActive = false;
            }
        }
    }
}
