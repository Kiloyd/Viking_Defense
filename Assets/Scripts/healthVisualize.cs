using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthVisualize : MonoBehaviour
{
    private healthManager hm;
    private Slider Bar;
    
    private void Start()
    {
        hm = FindObjectOfType<healthManager>();
        Bar = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        float BarValue = hm.getHealth();

        Bar.value = BarValue;
    }
}
