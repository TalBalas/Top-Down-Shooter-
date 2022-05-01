using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPoolSpawning : MonoBehaviour
{
    [SerializeField]  Queue<GameObject> ObjectsToSpawn = new Queue<GameObject>();
    public GameObject Prefab;
   
    public static BasicPoolSpawning instnace;
    private void Awake()
    {
        instnace = this;
    }
    
    public GameObject GetFromPool()
    {
        if (ObjectsToSpawn.Count == 0)
        {
            GrowPool();
           
        }
        var instance = ObjectsToSpawn.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    public void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instaceToAdd = Instantiate(Prefab);
            instaceToAdd.transform.SetParent(transform);
            AddTopool(instaceToAdd);
        }
    }
    public  void AddTopool(GameObject instance)
    {
        instance.SetActive(false);

        ObjectsToSpawn.Enqueue(instance);
    }
}
