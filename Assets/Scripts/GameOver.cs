using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button continueButton;
    //[SerializeField] PlayerHealth playerHealth;
    //[SerializeField] ScoreSystem scoreSystem;
    //[SerializeField] GameObject gameOverMenu;


    public void ContinueButton()
    {
        AdsHandler.Instance.LoadRewarded();
        AdsHandler.Instance.ShowRewarded();

        
        continueButton.interactable = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //public void Die()
    //{
    //    playerHealth.isDead = true;
    //    Time.timeScale = 0.5f;

    //    Invoke("DisablePlayer", 1);
    //    gameOverMenu.SetActive(true);
    //}

    //public void ContinueGame()
    //{
    //    playerHealth.isDead = false;
    //    Time.timeScale = 1.0f;
    //    playerHealth.gameObject.SetActive(true);
    //    gameOverMenu.SetActive(false);
    //    scoreSystem.gameObject.SetActive(true);
    //}
}
