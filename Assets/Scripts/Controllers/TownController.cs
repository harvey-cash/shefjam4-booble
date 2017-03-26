using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour {
    [SerializeField]
    private static int totalArea = 0;
    [SerializeField]
    private static int winArea = 100;
    public void SetWinArea(int area) { winArea = area; }
    public int GetProgress() { return (int)(100 * (totalArea / (float)winArea)); }

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

        if (totalArea <= 1) { StartCoroutine(GameController.gameControl.Lose()); }
        else if (totalArea >= winArea) {
            StartCoroutine(GameController.gameControl.Win());
        }

        else if (GetProgress() < 25) {
            GameController.playerControl.tilesDegrade = false;
            GameController.playerControl.rollSpeed = 3;
            GameController.meteorControl.meteorFreq = 0.5f;
        }
        else if (GetProgress() < 50) {
            GameController.playerControl.tilesDegrade = false;
            GameController.playerControl.rollSpeed = 4;
            GameController.meteorControl.meteorFreq = 1f;
        }
        else if (GetProgress() < 75) {
            GameController.playerControl.tilesDegrade = true;
            GameController.playerControl.rollSpeed = 5;
            GameController.meteorControl.meteorFreq = 1.5f;
        }
        else if (GetProgress() < 100)
        {
            GameController.playerControl.tilesDegrade = true;
            GameController.playerControl.rollSpeed = 7;
            GameController.meteorControl.meteorFreq = 2.5f;
        }

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
