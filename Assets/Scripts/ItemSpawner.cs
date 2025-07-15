using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnInterval = 15f;

    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();

        InvokeRepeating(nameof(SpawnItem), 5f, spawnInterval);
    }

    void SpawnItem()
    {
        if (player == null) return;

        float x = Random.Range(-Player.xLimit, Player.xLimit);
        float y = Random.Range(-Player.yLimit, Player.yLimit);

        Instantiate(itemPrefab, new Vector3(x, y, 0f), Quaternion.identity);
    }
}
