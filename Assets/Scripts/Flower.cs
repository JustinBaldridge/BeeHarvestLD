using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    //Collision collision;
    
    FlowerPair flower;
    int index;

    void Awake()
    {
        index = UnityEngine.Random.Range(0, FlowerManager.Instance.GetMaxLength());

        flower = FlowerManager.Instance.GetFlowerPair(index);
        if (TryGetComponent<Collectable>(out Collectable collectable))
        {
            sprite.sprite = flower.normalFlower;
        }

        if (TryGetComponent<Objective>(out Objective objective))
        {
            sprite.sprite = flower.wiltedFlower;
            objective.OnObjectiveCompleted += Objective_OnObjectiveCompleted; 
        }
    }

    private void Objective_OnObjectiveCompleted(object sender, EventArgs e)
    {
        sprite.sprite = flower.normalFlower;
    }
}
