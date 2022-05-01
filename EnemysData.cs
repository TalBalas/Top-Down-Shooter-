using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemysData : ScriptableObject
{
    [Header("Shoot")]
    public float ShootDistance;
    public float ShootTimerSet;
    public GameObject ProjectilePrefab;
    [Header("Attack")]

    public bool CanAttack;
    public float AttackDistance;

    [Header("Movement")]
    public float Speed;
    public float RotationDegress;


    [Header("Run")]
    public bool CanRun;
    public float AlienRunSpeed;
    public float HealthStartRunning;

    [Space]
    public float StartHealth;
    public int SpawnCount;
    public GameObject AlienPrefab;
    public int MoneyToAdd;


    public string Name;
}
