using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCube : MonoBehaviour {

    [SerializeField] private int health;
    private int maxHealth = 100;
    private int ordX, ordY;
    public void SetOrds(int y, int x)
    {
        ordY = y;
        ordX = x;
    }

    void Start()
    {
        health = maxHealth;
    }

    private bool canDamage = true;
	public void Damage(int damage)
    {
        if(canDamage)
        {
            health -= damage;

            if(gameObject.transform.childCount > 0)
            {
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.white, health / (float)maxHealth);
            }
            
            if (health <= 0)
            {
                canDamage = false;
                gameObject.AddComponent<Rigidbody>();
                PlayerController.ceiling[ordY, ordX] = null;

            }
        }
        
    }

    void Update()
    {
        //Damage(1);
    }
}
