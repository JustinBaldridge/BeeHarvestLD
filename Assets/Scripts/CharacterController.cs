using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event EventHandler OnPlayerDead;

    [SerializeField] LayerMask collisions;
    [SerializeField] int maxHealth;
    [SerializeField] float speed;

    //CircleCollider2D circleCollider; 
    Rigidbody2D body;
    Controller2D controller;

    int health;
    int pollen;
    int nectar;

    float collisionRadius;

    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //circleCollider = GetComponent<CircleCollider2D>();
        body = GetComponent<Rigidbody2D>();
        controller = GetComponent<Controller2D>();

        health = maxHealth;
        //collisionRadius = circleCollider.radius; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            moveDirection = mousePosition - transform.position;
            
        }
        else
        {
            moveDirection = Vector2.zero;
        }
    }
    
    void FixedUpdate()
    {
        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    public void AddPickup(int value = 1)
    {
        pollen += value;
        Debug.Log("CharacterController.cs  pollen = " + pollen);
    }

    public bool UsePickup(int value = 1)
    {
        Debug.Log("CharacterController.cs  pollen = "  + pollen + ", value = " + value);
        if (pollen < value) return false;

        pollen -= value; 
        nectar += value;
        return true;
    }

    public void TakeDamage(int value = 1)
    {
        health -= 1;
        Debug.Log("CharacterController.cs  health = " + health);
        if (health <= 0)
        {
            OnPlayerDead?.Invoke(this, EventArgs.Empty);
            Debug.Log("CharacterController.cs  Dead.");
        }
    }

    public int CollectNectar()
    {
        int n = nectar;
        nectar = 0;
        return n;
    }

    public void Reset()
    {
        health = maxHealth;
        pollen = 0;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetPollen()
    {
        return pollen;
    }

    public int GetNectar()
    {
        return nectar;
    }
}
