using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    public float invincibleTIme = 1.0f;
    public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
    }

    private void OnTirggerEnter(Collider other)
    {
        if (other.CompareTag("Missle"))
        {
            currentLives--;
            Destroy(other.gameObject);

            if (currentLives <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {

        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
