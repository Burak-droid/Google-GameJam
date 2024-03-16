using Shoot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

     public class Weapon : MonoBehaviour
    {
        public int damageAmount = 20;
        // Start is called before the first frame update
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Çarpıştığı cisim Enemy etiketine sahip ise hasar ver
            Enemy enemyHealth = collision.gameObject.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);

            }
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Platforms"))
        {
            Destroy(gameObject);
        }
    }
}


