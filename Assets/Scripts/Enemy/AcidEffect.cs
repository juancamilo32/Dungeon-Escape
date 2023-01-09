using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 3f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IDamageable hit = other.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.TakeDamage();
                Destroy(this.gameObject);
            }
        }
    }

}
