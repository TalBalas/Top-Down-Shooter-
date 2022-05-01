using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Coin;
    void Awake()
    {
        GameEvents.AlienDead += SpawnCoins;
    }
    void OnDestroy()
    {
        GameEvents.AlienDead -= SpawnCoins;
    }
    private void SpawnCoins(AliensDie.AliensDieData aliendata)
    {

            GameObject coin = Instantiate(Coin, aliendata.pos, Quaternion.identity);
           
    }
}
