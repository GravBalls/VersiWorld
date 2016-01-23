using UnityEngine;
using System.Collections.Generic;

public class GenerateObstacles : MonoBehaviour
{
    public int quantity;
    public Transform minPosition;
    public Transform maxPosition;
    public GameObject prefab;
    public float placementBuffer = .01f;
    

    List<GameObject> obstacles = new List<GameObject>();
    float prefabHalfWidth;
    void Awake()
    {
        prefabHalfWidth = prefab.GetComponent<Collider>().bounds.size.x * 0.5f;
        for (int i = 0; i < quantity; i++)
        {
            GameObject obstacle = Instantiate(prefab, GetRandomSpawnPosition(), Quaternion.Euler(Vector3.forward * Random.Range(30, 60))) as GameObject;
            obstacles.Add(obstacle);
        }

    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 result = new Vector3();
        int fuse = 0;//safety fuse for killing infinite loop
        while (true)
        {
            result = minPosition.position;
            result.x = Random.Range(minPosition.position.x, maxPosition.position.x);
           if(CheckIfClear(result))
            {
                return result;
            }
            Debug.Assert(++fuse < 100, "Safety fuse blown on infinite loop.");
            

        }
    }

    bool CheckIfClear(Vector3 position)
    {
        bool result = true;
        foreach (GameObject obstacle in obstacles)
        {
            float minX = obstacle.transform.position.x - (prefabHalfWidth + placementBuffer);
            float maxX = obstacle.transform.position.x + (prefabHalfWidth + placementBuffer);
            if (position.x > minX && position.x < maxX)//obstacle already there no need to search anymore get another random and try again
            {
                result = false;
                break;
            }
        }
        return result;
    }

}
