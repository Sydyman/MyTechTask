using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject roadPrefab;
    private List<GameObject> roadSegments = new List<GameObject>();
    private float spawnZ = 0f;  
    private float roadLength = 20f; 
    private int roadCount = 5; 
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

        for (int i = 0; i < roadCount; i++)
        {
            SpawnRoad();
        }
    }

    private void Update()
    {
        if (player.position.z - 20f > (spawnZ - roadCount * roadLength))
        {
            SpawnRoad();
            DeleteRoad();
        }
    }

    private void SpawnRoad()
    {
        GameObject road = Instantiate(roadPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
        roadSegments.Add(road);
        spawnZ += roadLength;
    }

    private void DeleteRoad()
    {
        Destroy(roadSegments[0]);
        roadSegments.RemoveAt(0);
    }
}
