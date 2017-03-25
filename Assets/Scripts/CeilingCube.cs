using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCube : MonoBehaviour {

    [SerializeField] private int health;
    private int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
    }

	public void Damage(int damage)
    {
        health -= damage;
        gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.white, health / (float)maxHealth);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //Damage(1);
    }
}
