using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collision : MonoBehaviour
{
    protected bool active = true;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (active)
        {
            if (other.gameObject.tag == "Player")
            {
                active = false;
                CharacterController player = other.gameObject.GetComponent<CharacterController>();

                CollisionEntry(player);
            }
        }
    }

    public bool IsActive()
    {
        return active;
    }

    protected abstract void CollisionEntry(CharacterController player);
}
