using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemoval : MonoBehaviour {

	void OnTriggerEnter(Collider toDestroy)
    {
        if(toDestroy.gameObject.GetComponent<Meteor>() != null || toDestroy.gameObject.GetComponent<CeilingCube>() != null)
        {
            Destroy(toDestroy.gameObject);
        }
    }
}
