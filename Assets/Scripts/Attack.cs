using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    bool canDealDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null)
        {
            if (canDealDamage)
            {
                hit.TakeDamage();
                canDealDamage = false;
                StartCoroutine(DamageCooldownRoutine());
            }
        }
    }

    IEnumerator DamageCooldownRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        canDealDamage = true;
    }

}
