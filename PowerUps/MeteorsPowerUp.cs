using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsPowerUp : PowerUp
{
    [SerializeField] Transform MeteorsPrefab;
    [SerializeField] float offset;
    public Transform OurPLayer;
    public int MeteorsCount = 10;
    [SerializeField] float RangePos = 4;
    protected override void Update()
    {
        base.Update();
    }
    protected override void ActivatePowerUpInternal()
    {
        for (int i = 0; i < MeteorsCount; i++)
        {
            float x = Random.Range(OurPLayer.position.x + RangePos, OurPLayer.position.x - RangePos);
            float z = Random.Range(OurPLayer.position.z + RangePos, OurPLayer.position.z - RangePos);
            float y =  offset;
            Vector3 randomPos = new Vector3(x, y, z);
            var meteor = Instantiate(MeteorsPrefab, randomPos, Quaternion.identity);
        }
    }
   
}
