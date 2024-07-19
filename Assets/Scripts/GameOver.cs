using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button continueButton;


    public void ContinueButton()
    {
        if (AdsHandler.Instance.rewardedVideoReady)
        {
            IronSource.Agent.showRewardedVideo();
        }
        continueButton.interactable = false;
    }


    public void PlayAgain()
    {
        if (AdsHandler.Instance.interstitialReady)
        {
            IronSource.Agent.showInterstitial();
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        IronSource.Agent.hideBanner();
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
}
