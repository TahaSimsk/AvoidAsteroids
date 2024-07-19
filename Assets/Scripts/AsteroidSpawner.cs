using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidPrefabs;
    [SerializeField] float secondsBetweenAsteroids;
    [SerializeField] Vector2 forceRange;

    [Header("Difficulty Settings")]

    [SerializeField][Tooltip("How often do you want to increase the difficulty? 'Eg. '10''")] float secondsForAsteroidVelocityDifficulty;

    [SerializeField][Tooltip("How much do you want to increse the difficulty per seconds above? 'Eg. 0.1'")] float difficultyMultiplierFloat;

    Camera mainCamera;
    float timerBetweenAsteroids;
    float timerForAsteroidVelocityDifficulty;
    float difficultyMultiplier = 1;

    Vector2 direction;
    Rigidbody rb;


    private void Start()
    {
        mainCamera = Camera.main;
    }


    void Update()
    {
        SpawnAsteroidTimer();
        DifficultyMultiplierTimer();
    }


    void SpawnAsteroidTimer()
    {
        timerBetweenAsteroids -= Time.deltaTime;
        if (timerBetweenAsteroids <= 0)
        {
            SpawnAsteroid();
            timerBetweenAsteroids = secondsBetweenAsteroids;
        }
    }


    void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        direction = Vector2.zero;

        switch (side)
        {
            case 0:
                spawnPoint.x = 0f;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1, 1));
                break;

            case 1:
                spawnPoint.x = 1f;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1, Random.Range(-1, 1));
                break;

            case 2:
                spawnPoint.x += Random.value;
                spawnPoint.y = 0f;
                direction = new Vector2(Random.Range(-1, 1), 1);
                break;

            case 3:
                spawnPoint.x += Random.value;
                spawnPoint.y += 1f;
                direction = new Vector2(Random.Range(-1, 1), -1);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);

        worldSpawnPoint.z = 0f;

        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

        GameObject asteroidInstance = Instantiate(selectedAsteroid, worldSpawnPoint, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        rb = asteroidInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y) * difficultyMultiplier;
    }


    void DifficultyMultiplierTimer()
    {
        timerForAsteroidVelocityDifficulty -= Time.deltaTime;

        if (timerForAsteroidVelocityDifficulty <= 0)
        {
            timerForAsteroidVelocityDifficulty = secondsForAsteroidVelocityDifficulty;
            difficultyMultiplier += difficultyMultiplierFloat;
        }
    }
}
