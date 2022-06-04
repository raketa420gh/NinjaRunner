using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadTileGenerator : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform playerTransform;
    
    [Header("Tiles")]
    [SerializeField] [Min(10)] private float tileLenght;
    [SerializeField] [Min(5)] private int startAllTilesCount;
    [SerializeField] [Min(1)] private int startTilesCount;
    [SerializeField] private GameObject startTilePrefab;
    [SerializeField] private GameObject[] tilePrefabs;

    private readonly List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPositionZ = 0;

    private void Start()
    {
        for (int i = 0; i < startAllTilesCount; i++)
        {
            if (i < startTilesCount)
            {
                SpawnStartRoadTile();
            }
            else
            {
                SpawnRandomRoadTile();
            }
        }
    }

    private void Update()
    {
        if (playerTransform.position.z - 50 > spawnPositionZ - (startAllTilesCount * tileLenght))
        {
            SpawnRandomRoadTile();
            DeleteRoadTile();
        }
    }

    private void SpawnRoadTile(int tileIndex)
    {
        var nextRoadTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPositionZ, transform.rotation);
        activeTiles.Add(nextRoadTile);
        spawnPositionZ += tileLenght;
    }

    private void SpawnStartRoadTile()
    {
        var nextRoadTile = Instantiate(startTilePrefab, transform.forward * spawnPositionZ, transform.rotation);
        activeTiles.Add(nextRoadTile);
        spawnPositionZ += tileLenght;
    }

    private void SpawnRandomRoadTile()
    {
        SpawnRoadTile(Random.Range(0, tilePrefabs.Length));
    }

    private void DeleteRoadTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}