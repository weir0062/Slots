using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotLine : MonoBehaviour
{
    public List<Color> SlotColors;
    public GameObject TopSlot;
    public GameObject MidSlot;
    public GameObject BottomSlot;
    public int currentSlot = 0;

    void Start()
    {
        Reset();
    }

    public IEnumerator Spinning(float duration, float speed)
    {
        Reset();
        float elapsed = 0f;

        while (elapsed < duration)
        {
            currentSlot = (currentSlot + 1) % SlotColors.Count;
            DisplayNeccessarySlots();
            elapsed += speed;
            yield return new WaitForSeconds(speed);
        }

        currentSlot = Random.Range(0, SlotColors.Count);
        Debug.Log("Current Slot ID after Random Stop: " + currentSlot);
        DisplayNeccessarySlots();
    }

    public void DisplayNeccessarySlots()
    {
        //TopSlot
        int topslotnum = currentSlot - 1;
        if (topslotnum < 0)
        {
            topslotnum = SlotColors.Count - 1;
        }
        TopSlot.GetComponent<SpriteRenderer>().color = SlotColors[topslotnum];
        
        //MidSlot
        MidSlot.GetComponent<SpriteRenderer>().color = SlotColors[currentSlot];

        //BottomSlot
        int bottomslotnum = currentSlot + 1;

        if (bottomslotnum > SlotColors.Count - 1)
        {
            bottomslotnum = 0;
        }
        BottomSlot.GetComponent<SpriteRenderer>().color = SlotColors[bottomslotnum];
    }

    public void Reset()
    {
        currentSlot = 0;
        SlotColors = new List<Color>
        {
            Color.black, Color.white, Color.blue, Color.red,
            new Color(1, 0.5f, 0), Color.green, Color.yellow,
            new Color(0.5f, 0, 0.5f), new Color(1, 0.5f, 0.5f),
            new Color(0.5f, 0.25f, 0)
        };
        DisplayNeccessarySlots();
    }
}
