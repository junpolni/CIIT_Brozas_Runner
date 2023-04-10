using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Player died");
            Die();

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obby"))
        {
            FindObjectOfType<SoundManager>().Play("ObbyDamageSFX");

            TakeDamage(1);
            Debug.Log($"Obby Hit Player. Remaining Health: {currentHealth}");

        }
    }

    private void Die()
    {
        FindObjectOfType<SoundManager>().Play("DeathSFX");

        Destroy(gameObject);
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
