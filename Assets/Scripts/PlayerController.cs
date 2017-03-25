using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum DirectionEnum { FORWARD, LEFT, RIGHT, BACK }

public class PlayerController : MonoBehaviour
{
    private static int maxLength = 15;
    private bool[,] ceilingBools = new bool[maxLength, maxLength];

    private Transform ceilingParent;
    private CeilingCube[,] ceiling = new CeilingCube[maxLength, maxLength];

    void Start()
    {
        ceilingParent = new GameObject("Ceiling Parent").transform;

        ceilingBools[maxLength / 2, maxLength / 2] = true;
        BuildCeiling(maxLength / 2, maxLength / 2);
    }

    void BuildCeiling(int j, int i)
    {
        if(ceiling[j, i] == null)
        {
            ceiling[j, i] = Instantiate((GameObject)Resources.Load("Prefabs/CeilingCube")).GetComponent<CeilingCube>();
            ceiling[j, i].transform.position = new Vector3(i - (maxLength / 2), 0, j - (maxLength / 2));
            ceiling[j, i].transform.parent = ceilingParent;
        }        
    }
    

    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) { RollInDirection(Vector3.forward, Vector3.right); }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) { RollInDirection(Vector3.back, Vector3.left); }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) { RollInDirection(Vector3.left, Vector3.forward); }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) { RollInDirection(Vector3.right, Vector3.back); }
    }
    
    void RollInDirection(Vector3 direction, Vector3 axis)
    {
        Vector3 nextPos = transform.position + direction;
        bool withinZBounds = ((int)Mathf.Round(nextPos.z) + (maxLength / 2) > 0 && (int)Mathf.Round(nextPos.z) + (maxLength / 2) < maxLength);
        bool withinXBounds = ((int)Mathf.Round(nextPos.x) + (maxLength / 2) > 0 && (int)Mathf.Round(nextPos.x) + (maxLength / 2) < maxLength);
        if(withinXBounds && withinZBounds)
        {
            Vector3 rotatePoint = transform.position + (0.5f * direction) + (0.5f * Vector3.down);
            transform.RotateAround(rotatePoint, axis, 90);
            
            BuildCeiling((int)Mathf.Round(transform.position.z) + (maxLength / 2), (int)Mathf.Round(transform.position.x) + (maxLength / 2));
        }        
    }
}
