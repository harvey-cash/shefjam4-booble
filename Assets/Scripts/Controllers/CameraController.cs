using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform cube;
    Vector3 offset;

    void Start()
    {
        cube = transform.parent;
        offset = transform.position - cube.position;
        transform.parent = null;       
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(cube.position + offset - transform.position);
    }
}
