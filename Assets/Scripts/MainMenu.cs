using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        if (AdsHandler.Instance.interstitialReady)
        {
            IronSource.Agent.showInterstitial();
            SceneManager.LoadScene(1);
            
        }

    }




}
