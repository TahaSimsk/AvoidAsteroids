using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStore : MonoBehaviour
{
    [SerializeField] GameObject whiteSparrow;
    [SerializeField] GameObject redSparrow;


    void Start()
    {
        if (PlayerPrefs.GetInt(Store.NewShipRedSparrowKey, 0) == 1)
        {
            whiteSparrow.SetActive(false);
            redSparrow.SetActive(true);
        }
       
    }
}
