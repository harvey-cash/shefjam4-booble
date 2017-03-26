using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour {
    [SerializeField]
    private static int totalArea = 0;
    [SerializeField]
    private static int winArea = 30;
    public void SetWinArea(int area) { winArea = area; }

    public void DeltaArea()
    {
        int sum = 0;
        for (int i = 0; i < towns.Count; i++)
        {
            sum += towns[i].GetArea();
        }
        totalArea = sum;

        if(totalArea <= 1) { gameObject.GetComponent<GameController>().Lose(); }
        if (totalArea >= winArea) { gameObject.GetComponent<GameController>().Win(); }
    }

    public static List<Town> towns = new List<Town>();
    public static void AddTown(Town newTown) { towns.Add(newTown); }

    private void Stop()
    {
        for(int i = 0; i < towns.Count; i++)
        {
            towns[i].Stop();
        }
    }
}
