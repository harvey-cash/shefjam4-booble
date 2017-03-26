using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour {
    [SerializeField]
    private static int totalArea = 0;
    [SerializeField]
    private static int winArea = 100;
    public int GetProgress() { return (int)(100 * (totalArea / (float)winArea)); }
    public void SetWinArea(int area) { winArea = area; }

    public Vector3 GetTextPos()
    {
        if(towns.Count > 0)
        {
            return new Vector3(towns[0].transform.position.x + (towns[0].transform.localScale.x / 2) + 1, 0, 0);
        }
        else
        {
            return new Vector3(6, 0, 0);
        }

    }

    bool damageOverTime = false;
    public bool GetDamageOverTime() { return damageOverTime; }

    public void DeltaArea()
    {
        int sum = 0;
        for (int i = 0; i < towns.Count; i++)
        {
            sum += towns[i].GetArea();
        }
        totalArea = sum;

        GameController.textControl.ProgressOutput(GetProgress().ToString() + " / 100");

        if(totalArea <= 1) { StartCoroutine(GameController.gameControl.Lose()); }

        if (GetProgress() < 25)
        {
            damageOverTime = false;
            GameController.playerControl.ROLL_SPEED = 3;
            GameController.meteorControl.meteorFreq = 0.5f;
        }
        if (GetProgress() >= 25 && GetProgress() < 50) {
            damageOverTime = false;
            GameController.playerControl.ROLL_SPEED = 4;
            GameController.meteorControl.meteorFreq = 1;
        }
        if (GetProgress() >= 50 && GetProgress() < 75)
        {
            damageOverTime = true;
            GameController.playerControl.ROLL_SPEED = 5;
            GameController.meteorControl.meteorFreq = 1.5f;
        }
        if (GetProgress() >= 75 && GetProgress() < 100)
        {
            damageOverTime = true;
            GameController.playerControl.ROLL_SPEED = 7;
            GameController.meteorControl.meteorFreq = 2.5f;
        }

        if (totalArea >= winArea) { StartCoroutine(GameController.gameControl.Win()); }
    }

    public static List<Town> towns = new List<Town>();
    public static void AddTown(Town newTown) { towns.Add(newTown); }

    public void Stop()
    {
        for(int i = 0; i < towns.Count; i++)
        {
            towns[i].Stop();
        }
    }
}
