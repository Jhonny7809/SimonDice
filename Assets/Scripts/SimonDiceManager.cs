using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonDiceManager : MonoBehaviour
{
    public List<Sprite> buttonSprites = new List<Sprite>(); // Lista para almacenar los sprites de los botones.
    public float timeBetweenColors = 1.0f; // Tiempo entre cada botón en la secuencia.

    public Image buttonImage; // El objeto de la interfaz que muestra el botón.

    //private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(PlayButtonSequence());
    }

    // Genera una secuencia aleatoria de botones.
    void GenerateRandomSequence(int length)
    {
        buttonSprites.Clear();

        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Range(0, buttonSprites.Count);
            buttonSprites.Add(buttonSprites[randomIndex]);
        }
    }

    // Reproduce la secuencia de botones generada.
    IEnumerator PlayButtonSequence()
    {
        GenerateRandomSequence(4); // Genera una secuencia de 4 botones (ajusta según tu nivel de dificultad).

        foreach (Sprite buttonSprite in buttonSprites)
        {
            // Muestra el botón y realiza el efecto de destello.
            ShowButton(buttonSprite);
            yield return new WaitForSeconds(timeBetweenColors);
        }
    }

    void ShowButton(Sprite buttonSprite)
    {
        // Cambia el sprite del botón para mostrar el nuevo color.
        buttonImage.sprite = buttonSprite;

        // Ajusta el brillo o cualquier otro efecto visual que desees para simular el destello.
        // Puedes modificar el material o los componentes de la imagen para lograr este efecto.
    }
}