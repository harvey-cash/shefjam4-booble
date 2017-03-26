using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    public MeteorSpawner(Town myTarget)
    {
        target = myTarget;
    }
    private Town target;
    public void SetTarget(Town town) { target = town; }

    public void Shower()
    {
        if(target.canChange)
        {
            GameObject meteor = Instantiate((GameObject)Resources.Load("Prefabs/Meteor"));
            meteor.transform.parent = MeteorController.meteorParent.transform;
            Vector3 spawnPos = new Vector3(target.transform.position.x, 20, target.transform.position.z);
            meteor.transform.position = spawnPos +
                                        (Random.Range(-target.transform.localScale.z / 2, target.transform.localScale.z / 2) * Vector3.forward) +
                                        (Random.Range(-target.transform.localScale.x / 2, target.transform.localScale.x / 2) * Vector3.right);
            meteor.GetComponent<Rigidbody>().velocity = Vector3.down * 10;
        }
        
    }
}
