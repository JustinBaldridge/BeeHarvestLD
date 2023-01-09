using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collision
{
    public GameObject particleSystem;

    void Start()
    {
        particleSystem.SetActive(false);
    }

    protected override void CollisionEntry(CharacterController player)
    {
        player.AddPickup();
        particleSystem.SetActive(true);
    }

    protected override void CollisionExit(CharacterController player)
    {
        
    }
}
