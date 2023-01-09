using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseAttack : MonoBehaviour
{
    [SerializeField] GameObject attackHitbox;
    [SerializeField] float attackTimer;
    [SerializeField] float attackDuration;

    float timer;

    void Update()
    {
        if (timer >= attackTimer)
        {
            StartCoroutine(ActivateAttack());
            timer = 0;
        } 
        else
        {
            timer += Time.deltaTime;
        }
    }

    IEnumerator ActivateAttack()
    {
        attackHitbox.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        attackHitbox.SetActive(false);
        
        timer = 0;
    }
}
