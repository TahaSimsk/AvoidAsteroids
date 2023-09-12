using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float maxHealth;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] ScoreSystem scoreSystem;

    //public bool hasCrashed = false;
    [HideInInspector] public bool isDead = false;

    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Time.timeScale = 1.0f;
        PassPlayerHealth();
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

        gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        isDead = false;
        Time.timeScale = 1.0f;
        gameObject.SetActive(true);
        gameOverMenu.SetActive(false);
        scoreSystem.gameObject.SetActive(true);
        currentHealth = maxHealth;
        transform.position = Vector3.zero;
    }

    public void Crash(float damage)
    {
        //hasCrashed = true;
        currentHealth -= damage;
    }

    void DisablePlayer()
    {
        gameObject.SetActive(false);
    }

    public void PassPlayerHealth()
    {
        AdsHandler.Instance.GetPlayerHeatlh(this);
    }


}
