using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float maxHealth;
    [SerializeField] GameObject gameOverMenu;

    //public bool hasCrashed = false;
    public bool isDead = false;

    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Time.timeScale = 1.0f;
    }


    void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
        Debug.Log(currentHealth);
    }



    void Die()
    {
        isDead = true;
        Time.timeScale = 0.5f;
        Destroy(gameObject, 1f);
        gameOverMenu.SetActive(true);
    }

    public void Crash(float damage)
    {
        //hasCrashed = true;
        currentHealth -= damage;
    }


}
