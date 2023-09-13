using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    public Text text;
    public SlotLine[] slotLines;
     
    public void Spin()
    {
        StartCoroutine(SpinningMachine());
    }

    public IEnumerator SpinningMachine()
    {
        text.text = "Spinning";
        List<int> finalResults = new List<int>();

        for (int i = 0; i < slotLines.Length; i++)
        {
            StartCoroutine(SpinIndividualLine(slotLines[i], i + 1, 0.069f, finalResults));
        }

        yield return new WaitUntil(() => finalResults.Count == slotLines.Length);
        CheckForWin(finalResults.ToArray());
    }

    public IEnumerator SpinIndividualLine(SlotLine slotLine, float duration, float speed, List<int> finalResults)
    {
        yield return slotLine.Spinning(duration, speed);
        finalResults.Add(slotLine.currentSlot);
    }

    void CheckForWin(int[] ids)
    {
        Debug.Log("Slot Line Results: " + ids[0] + "," + ids[1] + "," + ids[2]);


        if (ids.Length == 1 || ids.Length == 0) return;

        if (new HashSet<int>(ids).Count == 1)
        {
            text.text = "You Win";
        }
        else if (new HashSet<int>(ids).Count < ids.Length)
        {
            text.text = "Close";
        }
        else
        {
            text.text = "You Lose";
        }
    }
}
