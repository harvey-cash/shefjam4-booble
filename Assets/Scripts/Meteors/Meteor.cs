using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    private int minDamage = 60, maxDamage = 120;
    private bool canDamage = true;

	void OnTriggerEnter(Collider cube)
    {        
        if (canDamage)
        {
            if (cube.gameObject.GetComponent<PlayerController>() != null)
            {
                canDamage = false;
                Destroy(gameObject);
            }
            else if (cube.gameObject.GetComponent<Destroyable>() != null)
            {
                canDamage = false;
                cube.gameObject.GetComponent<Destroyable>().Damage(Random.Range(minDamage, maxDamage));
                Destroy(gameObject);
            }
        }        
    }
}
