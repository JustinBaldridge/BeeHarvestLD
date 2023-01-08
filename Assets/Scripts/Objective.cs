using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : Collision
{
    public static event EventHandler OnAnyObjectiveCompleted;

    protected override void CollisionEntry(CharacterController player)
    {
        if (!player.UsePickup())
        {
            active = true;
            return;
        }        
        
        OnAnyObjectiveCompleted?.Invoke(this, EventArgs.Empty);
    }

    protected override void CollisionExit(CharacterController player)
    {
        
    }
}
