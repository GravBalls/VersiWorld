using UnityEngine;
using System.Collections.Generic;

public class GenerateTargets : MonoBehaviour
{
    public int quantity;
    public Transform minPosition;
    public Transform maxPosition;
    public GameObject prefab;
    public float placementBuffer = .01f;


    List<GameObject> targets = new List<GameObject>();
    float prefabHalfWidth;
    void Awake()
    {
        prefabHalfWidth = prefab.GetComponent<Collider>().bounds.size.x * 0.5f;
    }

    public List<Target> Generate()
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject target = Instantiate(prefab, GetRandomSpawnPosition(), Quaternion.Euler(Vector3.forward * Random.Range(30, 60))) as GameObject;
            targets.Add(target);
        }
        List<Target> result = new List<Target>();
        foreach(GameObject target in targets)
        {
            Target t = target.GetComponent<Target>();
            result.Add(t);
        }
        return result;
    }


    Vector3 GetRandomSpawnPosition()
    {
        Vector3 result = new Vector3();
        int fuse = 0;//safety fuse for killing infinite loop
        while (true)
        {
            result = minPosition.position;
            result.x = Random.Range(minPosition.position.x, maxPosition.position.x);
            if (CheckIfClear(result))
            {
                return result;
            }
            Debug.Assert(++fuse < 100, "Safety fuse blown on infinite loop.");


        }
    }

    bool CheckIfClear(Vector3 position)
    {
        bool result = true;
        foreach (GameObject target in targets)
        {
            float minX = target.transform.position.x - (prefabHalfWidth + placementBuffer);
            float maxX = target.transform.position.x + (prefabHalfWidth + placementBuffer);
            if (position.x > minX && position.x < maxX)//obstacle already there no need to search anymore get another random and try again
            {
                result = false;
                break;
            }
        }
        return result;
    }

}
