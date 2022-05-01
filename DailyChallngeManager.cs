using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Linq;
public class DailyChallngeManager : MonoBehaviour
{
    public int NumOfChallanges = 3;
    [SerializeField] DailyChallangeData[] AllChallanges;
    [SerializeField] GameObject DailyChalllangePrefab;
    [SerializeField] Transform Locator;
    [SerializeField] float OffsetBetweenChallanges;
    [SerializeField] DailyChallange dailyChallange;

    void Awake()
    {
        GameEvents.ChallangeComplete += OnChallangeComplete;
    }
    void OnDestroy()
    {
        GameEvents.ChallangeComplete -= OnChallangeComplete;
    }
    void Start()
    {
        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        var timestamp = (int)Math.Round((DateTime.UtcNow - epochStart).TotalSeconds); // CurrentTime
        var lastChallangeTime = PlayerPrefs.GetInt("LastChallangeTime", 0);
        // How many time pass 
        if (timestamp - lastChallangeTime >= 24 * 60 * 60)
        {
           
            PlayerPrefs.SetInt("LastChallangeTime", timestamp);
            PlayerPrefs.Save();
            ReplaceChallnages();
        }
        Debug.Log($"{timestamp - lastChallangeTime} >= {24 * 60 * 60}");
        ShowChallanges();
     
    }
   
    private void ReplaceChallnages()
    {
        if (NumOfChallanges > AllChallanges.Length)
        {
            Debug.LogError($"Too Many Challanages Requested ({NumOfChallanges} > {AllChallanges.Length})"); return;
        }
        List<int> allIndexes = new List<int>();
        for (int x = 0; x < AllChallanges.Length; x++)
        {
            allIndexes.Add(x);
        }
        for (int i = 0; i < NumOfChallanges; i++)
        {
           var randonINdex = Random.Range(0, allIndexes.Count);
           var challange =  AllChallanges[allIndexes[randonINdex]];
           allIndexes.RemoveAt(randonINdex);
            PlayerPrefs.SetString("Challange" + i,challange.name);
        }
        PlayerPrefs.DeleteKey("ChallangeCompleted");
        PlayerPrefs.Save();
    }
    private void OnChallangeComplete(DailyChallangeData dailyChallangeData)
    {
        var challanges =PlayerPrefs.GetString("ChallangeCompleted");
        var splitChallanges = challanges.Split(',').ToList();
        splitChallanges.Add(dailyChallangeData.name);
        PlayerPrefs.SetString("ChallangeCompleted", string.Join(",",splitChallanges));
        PlayerPrefs.Save();
        Debug.Log(string.Join(",", splitChallanges));
    }
    private void ShowChallanges()
    {
        var challangesCompleted = PlayerPrefs.GetString("ChallangeCompleted");
        var splitChallangesCompleted = challangesCompleted.Split(',').ToList();
        for (int i = 0; i < NumOfChallanges; i++)
        {
           
          var challangeName =  PlayerPrefs.GetString("Challange" + i);
            if (splitChallangesCompleted.Contains(challangeName)) continue;
          var challange = AllChallanges.First(c => c.name == challangeName);
          

          var spawnChallange = Instantiate(DailyChalllangePrefab, Locator.position, Quaternion.identity, transform).GetComponent<DailyChallange>();
            
          spawnChallange.dailyChallangeData = challange;
          spawnChallange.transform.Translate(Vector3.down * OffsetBetweenChallanges * i);
           

        }
     
    }
   
}
