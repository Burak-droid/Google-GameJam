using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string platformTag = "Platforms";
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {

        string collidedTag = other.tag;

        if (collidedTag == platformTag || collidedTag == playerTag)
        {
            Destroy(gameObject);
        }
    }
}
