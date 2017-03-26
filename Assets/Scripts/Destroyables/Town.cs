using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : Destroyable {
    
    private int growBy = 1;
    private float growthRate = 5; //per minute
    private TownController controller;

    public void Start()
    {
        controller = GameController.townControl;
        StartCoroutine(Grow());
        TownController.AddTown(this);
    }
    public void Stop()
    {
        canChange = false;
    }
    public int GetArea() { return (int)(transform.localScale.x * transform.localScale.z); }

    public override void Damage(int damage)
    {
        if(canChange)
        {
            if (Random.Range(0f, 1f) > 0.5f)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - growBy);
                if (Random.Range(0f, 1f) > 0.5f) { transform.position += (Vector3.back * growBy / 2); }
                else { transform.position += (Vector3.forward * growBy / 2); }
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - growBy, transform.localScale.y, transform.localScale.z);
                if (Random.Range(0f, 1f) > 0.5f) { transform.position += (Vector3.left * growBy / 2); }
                else { transform.position += (Vector3.right * growBy / 2); }
            }

            if (transform.localScale.x * transform.localScale.z < 1)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
                canChange = false;
            }
            controller.DeltaArea();
        }

        
    }

    public bool canChange = true;
    private IEnumerator Grow()
    {
        if(canChange)
        {
            yield return new WaitForSeconds(60 / growthRate);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + growBy);
                if (Random.Range(0f, 1f) > 0.5f) { transform.position += (Vector3.back * growBy / 2); }
                else { transform.position += (Vector3.forward * growBy / 2); }
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + growBy, transform.localScale.y, transform.localScale.z);
                if (Random.Range(0f, 1f) > 0.5f) { transform.position += (Vector3.left * growBy / 2); }
                else { transform.position += (Vector3.right * growBy / 2); }
            }

            controller.DeltaArea();
            StartCoroutine(Grow());
        }
        
    }
}
