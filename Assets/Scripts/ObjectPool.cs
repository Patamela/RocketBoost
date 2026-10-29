using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> objectPoolList = new List<GameObject>();


    void Start()
    {
        CreatePool();
    }

    /// <summary>
    /// Create a pool of objects based on the specified pool size and object prefab
    /// </summary>
    private void CreatePool()
    {
        for(int i=0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    /// <summary>
    /// Instatiate new Object and add it to the pool list
    /// </summary>
    /// <returns></returns>
    private GameObject CreateNewObject()
    {
        // Instatiate a new object from the prefab
        GameObject newObject = Instantiate(objectPrefab);
        // Set the new object to inactivate and add it to the pool list
        newObject.SetActive(false);
        // Add the new object to the pool list
        objectPoolList.Add(newObject);
        // Return the new object
        return newObject;
    }

    /// <summary>
    /// Get an object from the pool
    /// </summary>
    /// <returns></returns>
    public GameObject GetObjectFromPool()
    {
        GameObject theObject = objectPoolList.Find(obj => !obj.activeInHierarchy);

        if(theObject == null)
        {
            theObject = CreateNewObject();
        }

        theObject.SetActive(true);
        return theObject;
    }

}
