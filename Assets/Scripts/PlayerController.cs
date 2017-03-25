using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum DirectionEnum { FORWARD, LEFT, RIGHT, BACK }

public class PlayerController : MonoBehaviour
{
    private static int maxLength = 9;
    private bool[,] ceilingBools = new bool[maxLength, maxLength];
    private GameObject[,] ceiling = new GameObject[maxLength, maxLength];

    void Start()
    {
        ceilingBools[maxLength / 2, maxLength / 2] = true;
        BuildCeiling();
    }

    void BuildCeiling()
    {
        for (int j = 0; j < maxLength; j++)
        {
            for (int i = 0; i < maxLength; i++)
            {
                if(ceilingBools[j, i] && ceiling[j, i] == null)
                {
                    Debug.Log("making new cube at " + i + ", " + j);
                    ceiling[j, i] = new GameObject(i + ", " + j);
                }
            }
        }
    }
    

    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {  RollInDirection(Vector3.forward, Vector3.right); }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) { RollInDirection(Vector3.back, Vector3.left); }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) { RollInDirection(Vector3.left, Vector3.forward); }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) { RollInDirection(Vector3.right, Vector3.back); }
    }

    private int initX = maxLength / 2, initY = maxLength / 2;
    void RollInDirection(Vector3 direction, Vector3 axis)
    {
        Vector3 rotatePoint = transform.position + (0.5f * direction) + (0.5f * Vector3.down);
        transform.RotateAround(rotatePoint, axis, 90);

        ceilingBools[(int)Mathf.Round(transform.position.z) + (maxLength / 2), (int)Mathf.Round(transform.position.x) + (maxLength / 2)] = true;
        BuildCeiling();
    }
}
