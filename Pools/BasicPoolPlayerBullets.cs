using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPoolPlayerBullets : MonoBehaviour
{
    [SerializeField]  Queue<GameObject> BulletsToSpawn = new Queue<GameObject>();
    [SerializeField] GameObject Prefab;
    [SerializeField] GameObject BoomBulletPrefab;


    public static BasicPoolPlayerBullets Instace;
    private void Awake()
    {
        Instace = this;
    }
  
    public GameObject GetFromPool()
    {
        if (BulletsToSpawn.Count == 0)
        {
            GrowPool();
           
        }
        var instance = BulletsToSpawn.Dequeue();
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
        BulletsToSpawn.Enqueue(instance);
    }
}
