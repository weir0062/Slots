using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int id;
    public Color color;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    public void SetColor(Color newColor)
    {
        color = newColor;
        spriteRenderer.color = newColor;
    }
    public void Show()
    {
        spriteRenderer.enabled = true;
    }
    public void Hide()
    {
        spriteRenderer.enabled = false;
    }
    public void SetID(int newID)
    {
        id = newID;
    }
}
