using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Collision
{
    protected override void CollisionEntry(CharacterController player)
    {
        player.TakeDamage();   
        active = true;        
    }

    protected override void CollisionExit(CharacterController player)
    {
        
    }
}
