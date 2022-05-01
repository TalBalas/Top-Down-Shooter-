using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


[System.Serializable]
public struct SpawnCommand
{
    public EnemysData enemysData;
}
[System.Serializable]
public struct SpawnWave
{
    public SpawnCommand[] commands;

}
public class SpawnWaveSystem : WaveOne
{
    [SerializeField] private SpawnWave[] spawnWaves;
    [SerializeField] private Transform EdgeLeft;
    [SerializeField] private Transform EdgeRight;
    public List<GameObject> AlienPosRefrences = new List<GameObject>();
    [SerializeField] private int currentSpawnWave = -1;
    [SerializeField] private int AliensInMap;
     public Action<int> WaveSpawn;


    void Awake()
    {
        GameEvents.AlienDead += AlienDead;
    }
    void OnDestroy()
    {
        GameEvents.AlienDead -= AlienDead;
    }
    private void Start()
    {
       // SpawnNextWave();
        StartCoroutine("WaveOneBegin", "Wave One");
   

    }

    void Update()
    {
        SpawnLogic();
        if (currentSpawnWave == 2 &&!IsWave)
        {
            IsWave = true;
           StartCoroutine("WaveOneBegin", "Wave Two");
          
        }
        if (currentSpawnWave == 4 && !IsWave )
        {
          
            StartCoroutine("WaveOneBegin", "Wave Three");
            IsWave = true;
        }
        
    }

   public void SpawnLogic()
    {
        if (CanSpawnNextWave())
            SpawnNextWave();
    }

    bool CanSpawnNextWave()
    {
   
        return (AliensInMap <= 0) ;
      
    }

    void SpawnNextWave()
    {
        currentSpawnWave++;

        if(currentSpawnWave >= spawnWaves.Length)
        {
            return;
        }

        foreach (var spawnCommand in spawnWaves[currentSpawnWave].commands)
        {
            for (int i = 0; i < spawnCommand.enemysData.SpawnCount; i++)
            {
                SpawnEnemy(spawnCommand.enemysData.AlienPrefab);
            }
           
        }
        WaveSpawn?.Invoke(currentSpawnWave);

    }

    public void SpawnEnemy(GameObject prefab)
    {
       
        var RandomInMap = new Vector3(Random.Range(EdgeRight.transform.position.x, EdgeLeft.position.x), 0.5f,
        Random.Range(EdgeRight.transform.position.z, EdgeLeft.position.z));
        var RefrenceAliens =  Instantiate(prefab, RandomInMap, Quaternion.identity);
        AlienPosRefrences.Add(RefrenceAliens);
        RefrenceAliens.GetComponent<AlienMovment>().Init(this);
        AliensInMap++;
    }
    public void AlienDead(AliensDie.AliensDieData aliendata)
    {
       
        AliensInMap--;
        AlienPosRefrences.Remove(aliendata.alien);
    }
}

