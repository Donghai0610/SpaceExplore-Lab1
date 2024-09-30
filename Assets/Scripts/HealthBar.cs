using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider
        ;
    public void setMaxHealth(int health)
    {
        Slider.maxValue= health;
        Slider.value = health;
    }
    public void setHealth(int health)
    {
        Slider.value= health;
    }
   
}
