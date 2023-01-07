using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite healthFull;
    public Sprite healthEmpty;

    public int maxHealth;

    private int currentHealth;

    public GameObject[] healthBars;

    private CharacterController bee;

    // Start is called before the first frame update
    void Start()
    {
        bee = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = bee.GetHealth();

        if (currentHealth >= maxHealth)
        {

        }
        else if (currentHealth == maxHealth - 1)
        {
            healthBars[0].GetComponent<Image>().sprite = healthEmpty;
        }
        else if (currentHealth == maxHealth - 2)
        {
            healthBars[1].GetComponent<Image>().sprite = healthEmpty;
        }
        else if (currentHealth == maxHealth - 3)
        {
            healthBars[2].GetComponent<Image>().sprite = healthEmpty;
        }
    }
}
