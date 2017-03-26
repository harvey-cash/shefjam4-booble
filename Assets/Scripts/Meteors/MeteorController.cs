﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {
    public static float meteorFreq = 0.5f; //per second
    public static GameObject meteorParent;

    private static List<MeteorSpawner> spawners = new List<MeteorSpawner>();

	public void Begin () {
        meteorParent = new GameObject("Meteor Parent");

        for(int i = 0; i < TownController.towns.Count; i++)
        {            

            GameObject meteorObject = new GameObject("spawner [" + i + "]");
            MeteorSpawner meteorSpawner = meteorObject.AddComponent<MeteorSpawner>();
            meteorSpawner.SetTarget(TownController.towns[i]);
            spawners.Add(meteorSpawner);
        }
        StartCoroutine(MeteorShower());
        
    }

    private bool play = true;
	public void Stop()
    {
        play = false;
    }
    
    private IEnumerator MeteorShower()
    {        
        yield return new WaitForSeconds(1f / meteorFreq);

        if (play) {
            for (int i = 0; i < spawners.Count; i++)
            {
                spawners[i].Shower();
            }
            StartCoroutine(MeteorShower());
        }      

        
    }
}

