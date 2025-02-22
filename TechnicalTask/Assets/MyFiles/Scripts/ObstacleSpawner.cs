using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject spherePrefab; 
    private List<GameObject> obstacles = new List<GameObject>();

    private float spawnZ = 30f; // Начальная позиция появления
    private float obstacleDistance = 10f; // Дистанция между препятствиями
    private int maxObstacles = 5; // Сколько препятствий одновременно в сцене
    private Transform player;
    private int positionIndex = 0; 
    private float[] positions = { -8f, -6, 1f }; 
 

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

        for (int i = 0; i < maxObstacles; i++)
        {
            SpawnObstacle();
        }
    }

    private void Update()
    {
        if (player.position.z - 15f > (spawnZ - maxObstacles * obstacleDistance))
        {
            SpawnObstacle();
            DeleteObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(positions[positionIndex], 0f, spawnZ);
        positionIndex = (positionIndex + 1) % positions.Length; 

        GameObject newObstacle = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
        obstacles.Add(newObstacle);

        spawnZ += obstacleDistance; 
    }

    private void DeleteObstacle()
    {
        if (obstacles.Count > maxObstacles)
        {
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
        }
    }
}
