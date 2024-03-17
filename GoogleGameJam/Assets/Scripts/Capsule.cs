using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Capsule : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("cave"))
        {

            Invoke("OyunuDurdur", 1f);
        }
    }


    void OyunuDurdur()
    {
        SceneManager.LoadSceneAsync("Eren-Platform");
    }
}
