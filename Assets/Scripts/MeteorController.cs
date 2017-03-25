using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {
    private float meteorFreq = 10;
    
	void Start () {
        StartCoroutine(MeteorShower());
    }
	
	void Update () {
		
	}

    private Vector3 spawnPos = new Vector3(0, 100, 0);
    private int maxRadius = 10;
    private IEnumerator MeteorShower()
    {
        GameObject meteor = Instantiate((GameObject)Resources.Load("Prefabs/Meteor"));
        meteor.transform.position = spawnPos + (Random.Range(-maxRadius, maxRadius) * Vector3.forward) + (Random.Range(-maxRadius, maxRadius) * Vector3.right);
        yield return new WaitForSeconds(1f / meteorFreq);
        StartCoroutine(MeteorShower());
    }
}
