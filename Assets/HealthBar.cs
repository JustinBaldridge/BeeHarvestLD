using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Sprite healthFull;
    public Sprite healthEmpty;

    public int maxHealth;

    public bool[] healthStatus;

    private CharacterController bee;

    // Start is called before the first frame update
    void Start()
    {
        healthStatus = new bool[maxHealth];

        bee = FindObjectOfType<CharacterController>();

        for(int i = 0; i < maxHealth; i++)
        {
            healthStatus[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            Debug.Log("health " + i + " = " + healthStatus[i]);
        }
    }
}
