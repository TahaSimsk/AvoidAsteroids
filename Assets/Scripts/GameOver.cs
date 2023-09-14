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
        if (AdsHandler.Instance.rewardedVideoReady)
        {
            IronSource.Agent.showRewardedVideo();
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = false;
        }

    }

    public void PlayAgain()
    {

        

        if (AdsHandler.Instance.interstitialReady)
        {
            IronSource.Agent.showInterstitial();
            IronSource.Agent.hideBanner();
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }

    public void MainMenu()
    {

        if (AdsHandler.Instance.interstitialReady)
        {
            IronSource.Agent.showInterstitial();
            IronSource.Agent.displayBanner();
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

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
