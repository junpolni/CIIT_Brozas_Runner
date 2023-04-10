using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public GameObject[] bodyParts;

    private Animator anim;
    private int currentParts = 3;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

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

    private void HealBalloon(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            anim.SetBool("isFloating", true);
            Debug.Log("Player can float");
        }
        //else if (currentHealth ==  maxHealth)
        //{
        //    anim.SetBool("isCrawling", false);
        //    Debug.Log("Player has complete limbs");
        //}
        else if (currentHealth <= maxHealth)
        {

            switch (currentHealth)
            {
                case 1:
                    bodyParts[3].SetActive(true);
                    currentParts++;
                    Debug.Log("Player gained a limb");
                    break;
                case 2:
                    bodyParts[2].SetActive(true);
                    currentParts++;
                    Debug.Log("Player gained a limb");
                    break;
                case 3:
                    bodyParts[1].SetActive(true);
                    currentParts++;
                    Debug.Log("Player gained a limb");
                    break;
                case 4:
                    bodyParts[0].SetActive(true);
                    anim.SetBool("isCrawling", false);
                    currentParts++;
                    Debug.Log("Player has complete limbs");
                    break;
            }

            //bodyParts[currentParts].SetActive(true);
            //currentParts++;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obby"))
        {
            FindObjectOfType<SoundManager>().Play("ObbyDamageSFX");

            TakeDamage(1);

            if (currentHealth > 0)
            {
                //Destroy(bodyParts[currentParts]);
                switch (currentHealth)
                {
                    case 0:
                        bodyParts[3].SetActive(false);
                        currentParts--;
                        break;
                    case 1:
                        bodyParts[2].SetActive(false);
                        currentParts--;
                        break;
                    case 2:
                        bodyParts[1].SetActive(false);
                        currentParts--;
                        break;
                    case 3:
                        bodyParts[0].SetActive(false);
                        anim.SetBool("isCrawling", true);
                        currentParts--;
                        break;
                    case 4:
                        anim.SetBool("isFloating", false);
                        break;
                }

                //bodyParts[currentParts].SetActive(false);
                //currentParts--;
            }

            //anim.SetBool("isCrawling", true);

            Debug.Log($"Obby Hit Player. Remaining Health: {currentHealth}");

        }

        if (collision.gameObject.CompareTag("Collectible"))
        {
            FindObjectOfType<SoundManager>().Play("BalloonCollectedSFX");

            HealBalloon(1);

            Destroy(collision.gameObject);
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
