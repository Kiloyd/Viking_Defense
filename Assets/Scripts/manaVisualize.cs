using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaVisualize : MonoBehaviour
{
    private Player_ControllerMove player;
    private Slider Bar;


    private void Start()
    {
        player = FindObjectOfType<Player_ControllerMove>();
        Bar = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        float BarValue = player.getTimeBar() / player.timeBarMaximum;

        Bar.value = BarValue;
    }
}
