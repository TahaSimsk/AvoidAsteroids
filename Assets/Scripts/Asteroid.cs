using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float damage;

    //private void Start()
    //{
    //    Renderer renderer = GetComponent<Renderer>();
    //    renderer.sortingLayerName = "Asteroid";
    //}
    bool hasCrashed;
    void Start()
    {
        hasCrashed = false;
    }

    void OnCollisionEnter(Collision other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            return;
        }
        if (!hasCrashed)
        {
            hasCrashed = true;
            playerHealth.Crash(damage);
        }
        

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
