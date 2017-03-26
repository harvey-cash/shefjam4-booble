using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour {
    [SerializeField]
    private static int totalArea = 0;
    [SerializeField]
    private static int money = 0, winArea = 30;

    public void Start()
    {
        StartCoroutine(EarnMoney());
    }

    public static void DeltaArea()
    {
        int sum = 0;
        for (int i = 0; i < towns.Count; i++)
        {
            sum += towns[i].GetArea();
        }
        totalArea = sum;

        if(totalArea <= 1) {  Debug.Log("You lose!"); MeteorController.Stop(); Stop(); }
        if (totalArea >= winArea) { Debug.Log("You win!"); MeteorController.Stop(); Stop(); }
    }

    public static List<Town> towns = new List<Town>();
    public static void AddTown(Town newTown) { towns.Add(newTown); }

    private IEnumerator EarnMoney()
    {
        yield return new WaitForSeconds(1f);
        money += totalArea;
        StartCoroutine(EarnMoney());
    }

    private static void Stop()
    {
        for(int i = 0; i < towns.Count; i++)
        {
            towns[i].Stop();
        }
    }
}
