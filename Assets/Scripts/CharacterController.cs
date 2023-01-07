using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event EventHandler OnPlayerDead;

    [SerializeField] int maxHealth;
    int health;
    int honey;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }

    public void AddPickup(int value = 1)
    {
        honey += value;
        Debug.Log("CharacterController.cs  honey = " + honey);
    }

    public bool UsePickup(int value = 1)
    {
        Debug.Log("CharacterController.cs  honey = "  + honey + ", value = " + value);
        if (honey < value) return false;

        honey -= value; 
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

    public void Reset()
    {
        health = maxHealth;
        honey = 0;
    }
}
