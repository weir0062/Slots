using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class SlotLine : MonoBehaviour
{/*
    public enum SlotColor
    {
        Red,
        White,
        Black,
        Brown,
        Orange,
        Green,
        Yellow,
        Purple,
        Pink,
        Blue
    }*/
    public List<Color> SlotColors;
    public GameObject TopSlot;
    public GameObject MidSlot;
    public GameObject BottomSlot;
    int currentSlot = 0;


    void Start()
    {
        // Initialize the list of Slots with default colors
        SlotColors = new List<Color>
        {
            Color.black,
            Color.white,
            Color.blue,                       
            Color.red,
            new Color(1, 0.5f, 0), // Orange
            Color.green,
            Color.yellow,
            new Color(0.5f, 0, 0.5f), // Purple
            new Color(1, 0.5f, 0.5f), // Pink
            new Color(0.5f, 0.25f, 0), // Brown
        };
        DisplayNeccessarySlots();
    }
    public void Spin(float duration, float speed)
    {
        StartCoroutine(Spinning(duration, speed));
    }

    public IEnumerator Spinning(float duration, float speed)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Hide all slots first
           // TopSlot.GetComponent<SpriteRenderer>().enabled = false;
          //  MidSlot.GetComponent<SpriteRenderer>().enabled = false;
           // BottomSlot.GetComponent<SpriteRenderer>().enabled = false;
            // Show the current slot
            currentSlot = (currentSlot + 1) % SlotColors.Count;
            DisplayNeccessarySlots();

            elapsed += speed;  // Update elapsed time
            yield return new WaitForSeconds(speed); // Wait for the next update
        }

        // Stop at a random slot after the duration
        currentSlot = Random.Range(0, SlotColors.Count);
        DisplayNeccessarySlots();
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        {
            Spin(2f, Time.deltaTime*0.5f);
        }
    }

    public void DisplayNeccessarySlots()
    {
        //top slot
        int topslotnum = currentSlot - 1;
        if (topslotnum < 0)
        {
            topslotnum = SlotColors.Count - 1;
        }
        TopSlot.GetComponent<SpriteRenderer>().color = SlotColors[topslotnum];
        //mid slot
        MidSlot.GetComponent<SpriteRenderer>().color = SlotColors[currentSlot];
        //bottom slot
        int bottomslotnum = currentSlot + 1;
        if (bottomslotnum > SlotColors.Count - 1)
        {
            bottomslotnum = 0;
        }
        BottomSlot.GetComponent<SpriteRenderer>().color = SlotColors[bottomslotnum];


    }
}

/*    public List<GameObject> SlotObjects;
    public Vector2 VisibleSlotPos1;
    public Vector2 VisibleSlotPos2;
    public Vector2 VisibleSlotPos3;
    private List<Slot> Slots = new List<Slot>();  // Initialize the list here
    private int currentIndex = 0;

    void Start()
    {
        Slots = new List<Slot>();
        for (int i = 0; i < SlotObjects.Count; i++)
        {
            Slot tempSlot = SlotObjects[i].GetComponent<Slot>();
            if (tempSlot != null)
            {
                Slots.Add(tempSlot);
            }
        }
        VisibleSlotPos1 = new Vector2(-1, 0);
        VisibleSlotPos2 = new Vector2(0, 0);
        VisibleSlotPos3 = new Vector2(1, 0);
        // Display slots 10, 1, and 2 at positions 1, 2, and 3
        DisplaySlot(Slots[9], VisibleSlotPos1);
        DisplaySlot(Slots[0], VisibleSlotPos2);
        DisplaySlot(Slots[1], VisibleSlotPos3);
    }

    private void DisplaySlot(Slot slot, Vector2 position)
    {
        slot.Show();
        slot.transform.position = position;
    }
}
*/



/*    public void Spin(float duration, float speed)
    {
        StartCoroutine(Spinning(duration, speed));
    }

    private IEnumerator Spinning(float duration, float speed)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Hide all slots first
            foreach (Slot slot in slotsInLine)
            {
                slot.Hide();
            }
            // Show the current slot
            slotsInLine[currentIndex].Show();
            // Move to the next slot
            currentIndex = (currentIndex + 1) % slotsInLine.Count;

            elapsed += speed;  // Update elapsed time
            yield return new WaitForSeconds(speed); // Wait for the next update
        }

        // Stop at a random slot after the duration
        currentIndex = Random.Range(0, slotsInLine.Count);
        foreach (Slot slot in slotsInLine)
        {
            slot.Hide();
        }
        slotsInLine[currentIndex].Show();
    }*/