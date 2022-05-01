using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveOne : MonoBehaviour
{
    [Header("WaveText")]
    public GameObject Wave;
    public Animator WaveANIM;
    public Text WavsText;
    public bool IsWave;

    IEnumerator WaveOneBegin(string waveOne)
    {
            WavsText.text = waveOne;
            yield return new WaitForSeconds(2);
            Wave.SetActive(true);
            yield return new WaitForSeconds(1.2f);
            Wave.SetActive(false);
    }
}
