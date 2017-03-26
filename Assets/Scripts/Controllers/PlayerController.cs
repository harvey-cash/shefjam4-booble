using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static int maxWidth = 25;
    public static CeilingCube[,] ceiling = new CeilingCube[maxWidth, maxWidth];

    private Transform ceilingParent;
    private Vector3 startVector;

    void Start()
    {
        startVector = transform.position;
        ceilingParent = new GameObject("Ceiling Parent").transform;
        
    }

    public void Reset()
    {
        for(int i = 0; i < maxWidth; i++)
        {
            for (int j = 0; j < maxWidth; j++)
            {
                if (ceiling[j, i] != null) { Destroy(ceiling[j, i].gameObject); }
                transform.position = startVector;
            }
        }
    }

    void BuildCeiling(int j, int i)
    {
        if(ceiling[j, i] == null)
        {
            ceiling[j, i] = Instantiate((GameObject)Resources.Load("Prefabs/CeilingCube")).GetComponent<CeilingCube>();
            ceiling[j, i].SetOrds(j, i);
            ceiling[j, i].transform.position = new Vector3(i - (maxWidth / 2), 0, j - (maxWidth / 2));
            ceiling[j, i].transform.parent = ceilingParent;

            //transform.position = startVector + Vector3.up;
        }
        else
        {
            ceiling[j, i].Repair();
        }
    }
    

    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) { RollInDirection(Vector3.forward, Vector3.right); }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) { RollInDirection(Vector3.back, Vector3.left); }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) { RollInDirection(Vector3.left, Vector3.forward); }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) { RollInDirection(Vector3.right, Vector3.back); }
    }
    
    void RollInDirection(Vector3 direction, Vector3 axis)
    {
        if(canRoll)
        {
            Vector3 nextPos = transform.position + direction;            

            bool withinZBounds = ((int)Mathf.Round(nextPos.z) + (maxWidth / 2) > 0 && (int)Mathf.Round(nextPos.z) + (maxWidth / 2) < maxWidth);
            bool withinXBounds = ((int)Mathf.Round(nextPos.x) + (maxWidth / 2) > 0 && (int)Mathf.Round(nextPos.x) + (maxWidth / 2) < maxWidth);

            if (withinXBounds && withinZBounds)
            {
                Vector3 rotatePoint = transform.position + (0.5f * direction) + (0.5f * Vector3.down);                
                StartCoroutine(Roll(rotatePoint, axis));                
            }
        }
        
    }

    private bool canRoll = true;
    private const float ROLL_SPEED = 3;
    private IEnumerator Roll(Vector3 rotatePoint, Vector3 axis)
    {
        canRoll = false;

        GameObject nextTransform = GetNextTransform(new GameObject().transform, rotatePoint, axis);
        Vector3 nextPos = nextTransform.transform.position;
        Quaternion nextRot = nextTransform.transform.rotation;
        Destroy(nextTransform);

        float totalRotation = 0;
        while (totalRotation < 90)
        {
            transform.RotateAround(rotatePoint, axis, 90 * Time.deltaTime * ROLL_SPEED);
            totalRotation += 90 * Time.deltaTime * ROLL_SPEED;

            yield return new WaitForEndOfFrame();
        }

        transform.position = nextPos;
        transform.rotation = nextRot;
        
        BuildCeiling((int)Mathf.Round(transform.position.z) + (maxWidth / 2), (int)Mathf.Round(transform.position.x) + (maxWidth / 2));

        canRoll = true;
    }

    private GameObject GetNextTransform(Transform temporary, Vector3 rotatePoint, Vector3 axis)
    {
        temporary.position = transform.position;
        temporary.rotation = transform.rotation;

        temporary.RotateAround(rotatePoint, axis, 90);

        return temporary.gameObject;
    }
}
