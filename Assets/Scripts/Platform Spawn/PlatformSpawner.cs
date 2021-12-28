using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject kalePrefab;
    public float platform_Spawn_Timer = 5f;
    private float current_Platform_Spawn_Timer;

    public float min_X = -2f, max_x = 2f;

    private void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    private void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;
        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_x);
            GameObject newPlatform = null;
            newPlatform = Instantiate(kalePrefab, temp, Quaternion.identity);
            
            newPlatform.transform.parent = transform;
            current_Platform_Spawn_Timer = 0f;
        } // spawn platform  
    }
}