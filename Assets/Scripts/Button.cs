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
        sprite.color = Color.white;
    }

    private void OnMouseUp()
    {
        sprite.color = Color.gray;

        manager.FigurePressed(id);

    }


}
