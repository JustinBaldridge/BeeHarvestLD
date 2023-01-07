using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event EventHandler OnPlayerDead;

    [SerializeField] int maxHealth;
    [SerializeField] float speed;
    int health;
    int pollen;
    int nectar;

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

            Vector3 target = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
            transform.position = new Vector3(target.x, target.y, 0);
            //transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
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
}
