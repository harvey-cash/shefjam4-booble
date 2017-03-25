using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemoval : MonoBehaviour {

	void OnTriggerEnter(Collider meteor)
    {
        if(meteor.gameObject.GetComponent<Meteor>() != null)
        {
            Destroy(meteor.gameObject);
        }
    }
}
