using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static Transform EntitiesContainer;

    public static List<PooledObjectInfo> ObjectPools = new();

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PooledObjectInfo pool = null;

        foreach (PooledObjectInfo p in ObjectPools)
        {
            if (p.ObjectsName == objectToSpawn.name)
            {
                pool = p;
                break;
            }
        }

        if (pool == null)
        {
            pool = new() { ObjectsName = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        GameObject spawnableObject = null;
        foreach (GameObject obj in pool.InactiveObjects)
        {
            if (obj != null)
            {
                spawnableObject = obj;
                break;
            }
        }

        if (spawnableObject != null)
        {
            spawnableObject.transform.position = spawnPosition;
            spawnableObject.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObject);
            spawnableObject.SetActive(true);
        }
        else
        {
            spawnableObject = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            spawnableObject.name = objectToSpawn.name;

            if (EntitiesContainer != null)
            {
                spawnableObject.transform.parent = EntitiesContainer;
            }
        }

        return spawnableObject;
    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.ObjectsName == obj.name);

        if (pool != null)
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
        else
        {
            Debug.LogWarning("Trying to realease object that is not pooled: " + obj.name);
        }
    }
}

public class PooledObjectInfo
{
    public string ObjectsName;
    public List<GameObject> InactiveObjects = new();
}
