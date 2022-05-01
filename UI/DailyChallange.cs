using UnityEngine;
using UnityEngine.UI;

public class DailyChallange : MonoBehaviour
{
    public DailyChallangeData dailyChallangeData;
    public Slider slideR;
    [SerializeField] Text text;
    public void Start()
    {
       
        slideR.maxValue = dailyChallangeData.TargetValue;
        text.text = dailyChallangeData.Name;
        slideR.value = PlayerPrefs.GetInt(dailyChallangeData.MemoryID, 0);

    }
    public void RewardButton()
    {
      
      if (slideR.value == slideR.maxValue)
      {
          GameEvents.ChallangeComplete?.Invoke(dailyChallangeData);
           Destroy(gameObject);
        
      }
        
    }

}
