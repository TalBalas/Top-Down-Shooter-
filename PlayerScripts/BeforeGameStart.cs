using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class BeforeGameStart : MonoBehaviour
{
    [SerializeField] SpawnWaveSystem spawnWaveSystem;
    [SerializeField] PlayableDirector Timeline;
  
    void Start()
    {
        
    }

   
    void Update()
    {

        if(Timeline.state == PlayState.Paused)
        {
          
            spawnWaveSystem.SpawnLogic();
          
        }
    }
}
