using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;       
    public Transform[] spawnPoints;         
    public Sprite[] asteroidSprites;        

    private Vector2[] directions = new Vector2[]
    {
        new Vector2(-0.5f, -1f).normalized,
        new Vector2(-0.25f, -1f).normalized,
        new Vector2(0f, -1f),
        new Vector2(0.25f, -1f).normalized,
        new Vector2(0.5f, -1f).normalized
    };

    private float[] speeds = { 1f, 2.5f, 4f, 7f };

    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 1f, 0.6f); 
    }

    void SpawnAsteroid()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        
        GameObject obj = Instantiate(asteroidPrefab, spawnPoint.position, Quaternion.identity);
        Asteroid asteroid = obj.GetComponent<Asteroid>();
        
        Vector2 dir = directions[Random.Range(0, directions.Length)];
        float speed = speeds[Random.Range(0, speeds.Length)];
        Sprite sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];

        asteroid.Init(dir, speed, sprite);
    }
}
