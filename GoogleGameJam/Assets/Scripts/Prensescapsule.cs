using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prensescapsule : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Prenses"))
        {

            Invoke("OyunuDurdur", 1f);
        }
    }


    void OyunuDurdur()
    {
        SceneManager.LoadSceneAsync("HappyEnding");
    }

}
