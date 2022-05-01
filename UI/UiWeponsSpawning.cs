using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class UiWeponsSpawning : MonoBehaviour
{
    [Serializable]
    public struct SpawnData
    {
        public int StartWave;
        public int ForceSpawnWave;
        public float MinTime;
        public float MaxTime;
        public WeaponData weaponData;
    }
    [SerializeField] private Transform LeftMap, RightMap;
    [SerializeField] List<GameObject> WeaponsToSpawn;
    [SerializeField] SpawnWaveSystem WaveSystem;
    [SerializeField] SpawnData[] WeaponsSpawnData;
 
    private float WaveTime;
    private int CurrentWeapon;
    private int CurrentWave;
    private float SpawnTime;
    void Start()
    {
        WaveSystem.WaveSpawn += SpawnUIWeapons;
        SpawnTime = Random.Range(WeaponsSpawnData[CurrentWeapon].MinTime, WeaponsSpawnData[CurrentWeapon].MaxTime);
    }
    void OnDestroy()
    {
        WaveSystem.WaveSpawn -= SpawnUIWeapons;
    }
    void Update()
    {
        if (CurrentWeapon >= WeaponsSpawnData.Length) return;
        if(CurrentWave>=WeaponsSpawnData[CurrentWeapon].StartWave && Time.time >= WaveTime + SpawnTime)
        {
            SpawnWeapon();
        }
    }
    void SpawnUIWeapons(int wave)
    {
        if (CurrentWeapon >= WeaponsSpawnData.Length) return;

        WaveTime = Time.time;
        if(WeaponsSpawnData[CurrentWeapon].ForceSpawnWave == wave)
        {
            SpawnWeapon();
            return;
        }
        CurrentWave = wave;
    }
    private void SpawnWeapon()
    {
        GameObject RandomWeapons = GetWeaponToSpawn(WeaponsToSpawn);
        WeaponsToSpawn.Remove(RandomWeapons);
        var RandomInMap = new Vector3(Random.Range(RightMap.transform.position.x, LeftMap.position.x), 0,
        Random.Range(RightMap.transform.position.z, LeftMap.position.z));
        Instantiate(RandomWeapons, RandomInMap, Quaternion.identity,transform);
        CurrentWeapon++;
        if (WeaponsToSpawn.Count <= 0) return;
        SpawnTime = Random.Range(WeaponsSpawnData[CurrentWeapon].MinTime, WeaponsSpawnData[CurrentWeapon].MaxTime);
    }
    private GameObject GetWeaponToSpawn(List<GameObject> WeaponsToSpawn)
    {
        int random = Random.Range(0, WeaponsToSpawn.Count);
        return WeaponsToSpawn[random];
    }
}
