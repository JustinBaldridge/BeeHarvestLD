using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseAttack : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;

    [SerializeField] GameObject attackHitbox;
    [SerializeField] float attackTimer;
    [SerializeField] float attackDuration;

    CharacterController player;

    float timer;

    void Start()
    {
        player = FindObjectOfType<CharacterController>();
    }

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

        Vector3 dir = player.gameObject.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        sprite.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    IEnumerator ActivateAttack()
    {
        attackHitbox.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        attackHitbox.SetActive(false);
        
        timer = 0;
    }
}
