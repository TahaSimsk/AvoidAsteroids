using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject store;

    public void Play()
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

    public void Store()
    {
        store.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Back()
    {
        store.SetActive(false);
        gameObject.SetActive(true);
    }




}
