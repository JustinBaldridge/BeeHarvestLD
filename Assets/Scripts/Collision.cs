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

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController player = other.gameObject.GetComponent<CharacterController>();

            CollisionExit(player);
        }
    }

    public virtual void Reset()
    {
        active = true;
    }

    public bool IsActive()
    {
        return active;
    }

    protected abstract void CollisionEntry(CharacterController player);

    protected abstract void CollisionExit(CharacterController player);
}
