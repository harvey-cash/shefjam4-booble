using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    private int minDamage = 20, maxDamage = 100;

	void OnTriggerEnter(Collider cube)
    {        
        if(cube.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }
        else if (cube.gameObject.GetComponent<CeilingCube>() != null)
        {
            cube.gameObject.GetComponent<CeilingCube>().Damage(Random.Range(minDamage, maxDamage));
            Destroy(gameObject);
        }
    }
}
