using System;
using UnityEngine;
public static class GameEvents
{
    public static Action<AliensDie.AliensDieData> AlienDead;
    public static Action<DailyChallangeData> ChallangeComplete;
    public static Action<float> takeDamage;
    public static Action<AlienHitData> AlienHit;

    public struct AlienHitData
    {
        public DamageTypePlayer.DamageType damageType;
        public float Damage;
        public float AlienHealth;


    }

}
