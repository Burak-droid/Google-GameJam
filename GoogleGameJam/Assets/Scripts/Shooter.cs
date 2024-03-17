using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject enemy;
    public Transform Flower;
    public float shootInterval = 2.5f;
    private float shootTimer = 0f;

    void Update()
    {
        shootTimer += Time.deltaTime;


        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }

    }
    void Shoot()
    {
        GameObject Go = Instantiate(enemy, Flower.position, Quaternion.identity);
        Rigidbody2D rb = Go.GetComponent<Rigidbody2D>();


        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 direction = (playerPosition - Go.transform.position).normalized;


        if (rb != null)
        {

            rb.AddForce(direction * 300f);
        }
    }

    void DestroyEnemy()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

    }
}
