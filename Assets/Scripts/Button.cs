using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private SpriteRenderer sprite;

    public int id;

    private Manager manager;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (manager.gameActive)
        {
            sprite.color = Color.white;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnMouseUp()
    {

        if (manager.gameActive)
        {
            sprite.color = Color.gray;
            manager.FigurePressed(id);
        }

    }


}
