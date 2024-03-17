using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public Slider healthSlider; // Sağlık çubuğu referansı
    private float canSayisi = 5;

    private void Start()
    {
        // deathCount0 değerini PlayerPrefs'ten yükle
        int deathCount0 = PlayerPrefs.GetInt("DeathCount5", 5);
        Debug.Log("Loaded Death Count: " + deathCount0);

        healthSlider.maxValue = canSayisi;
        healthSlider.value = canSayisi;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Border"))
        {
            if (other.gameObject.CompareTag("Border"))
            {
                canSayisi = 0;
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                canSayisi -= 0.5f;
                healthSlider.value = canSayisi;
            }

            if (canSayisi <= 0)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            }
        }
    }
}
