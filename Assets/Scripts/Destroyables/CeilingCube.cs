using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCube : Destroyable {

    [SerializeField] private float health;
    private int maxHealth = 100;
    private bool degrade;

    private int ordX, ordY;
    public void SetOrds(int y, int x)
    {
        ordY = y;
        ordX = x;
    }

    void Start()
    {
        health = maxHealth;
        degrade = GameController.townControl.GetDamageOverTime();
    }

    private bool canDamage = true;
	public override void Damage(float damage)
    {
        if(canDamage)
        {
            health -= damage;

            if(gameObject.transform.childCount > 0)
            {
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.white, health / maxHealth);
            }
            
            if (health <= 0)
            {
                canDamage = false;
                gameObject.AddComponent<Rigidbody>();
                PlayerController.ceiling[ordY, ordX] = null;
            }
        }
        
    }

    public void Repair()
    {
        health = maxHealth;
        if (gameObject.transform.childCount > 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.white, health / maxHealth);
        }
    }

    void Update()
    {
        if (degrade) { Damage(Time.deltaTime * (maxHealth / 60)); }
    }

}
