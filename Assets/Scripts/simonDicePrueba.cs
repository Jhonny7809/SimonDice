using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SimonSays : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    private List<int> sequence = new List<int>();
    private List<int> playerInput = new List<int>();

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerText;
    private bool isShowingSequence = false;
    private bool waitingForPlayer = false;
    public float difficultyAdder = 1.5f;
    public float animationLimit;

    public float timeBetweenButtons = .5f;

    private void Start()
    {
        Score.Score1 = 0;
        StartCoroutine(ShowNextSequence());
    }

    private IEnumerator ShowNextSequence()
    {
        waitingForPlayer = false;
        isShowingSequence = true;
        playerText.text = "Espera*";

        int nextInSequence = Random.Range(0, buttons.Count);
        sequence.Add(nextInSequence);

        foreach (int i in sequence)
        {
            yield return new WaitForSeconds(timeBetweenButtons);
            HighlightButton(buttons[i]);
            yield return new WaitForSeconds(timeBetweenButtons);
        }

        playerText.text = "Tu Turno!";
        isShowingSequence = false;
        waitingForPlayer = true;
    }

    private void HighlightButton(Button btn)
    {
        var originalColor = btn.GetComponent<Image>().color;
        btn.GetComponent<Image>().color = Color.red;

        StartCoroutine(ReturnColorAfterDelay(btn, originalColor, 0.5f));
    }

    private IEnumerator ReturnColorAfterDelay(Button btn, Color originalColor, float delay)
    {
        yield return new WaitForSeconds(delay);
        btn.GetComponent<Image>().color = originalColor;
    }

    public void ButtonClicked(int index)
    {
        if (waitingForPlayer)
        {
            playerInput.Add(index);

            if (playerInput[playerInput.Count - 1] != sequence[playerInput.Count - 1])
            {
                Debug.Log("Vales pa pura vrga");
                SceneManager.LoadScene("GameOver");

            }
            else if (playerInput.Count == sequence.Count)
            {
                Debug.Log("Bravo, no estas tan pendej@");
                Score.Score1 += 1;
                scoreText.text = Score.Score1.ToString();
                timeBetweenButtons *= difficultyAdder;
                timeBetweenButtons = Mathf.Clamp(timeBetweenButtons, animationLimit, float.MaxValue);
                playerInput.Clear();
                StartCoroutine(ShowNextSequence());
            }
        }
    }
}