using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    private Slider prgrssBar;

    void Start()

    {
        prgrssBar = GetComponent<Slider>();

        StartCoroutine(OnProgress());
    }

    private IEnumerator OnProgress()
    {
        while (true)
        { 
        yield return new WaitForSeconds(1);
        prgrssBar.value++;
        if (prgrssBar.value == prgrssBar.maxValue) prgrssBar.value = prgrssBar.minValue;
        }
    }
    
}
