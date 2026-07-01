using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindUIController : MonoBehaviour
{
    public DynamicWindController windController;

    [Header("UI")]
    public Slider strengthSlider;
    public Slider xSlider;
    public Slider zSlider;

    void Start()
    {
        strengthSlider.value = windController.windStrength;
        xSlider.value = windController.windDirection.x;
        zSlider.value = windController.windDirection.z;

        strengthSlider.onValueChanged.AddListener(UpdateWindStrength);
        xSlider.onValueChanged.AddListener(UpdateWindX);
        zSlider.onValueChanged.AddListener(UpdateWindZ);
    }

    void UpdateWindStrength(float value)
    {
        windController.windStrength = value;
    }

    void UpdateWindX(float value)
    {
        windController.windDirection =
            new Vector3(value, 0, windController.windDirection.z);
    }

    void UpdateWindZ(float value)
    {
        windController.windDirection =
            new Vector3(windController.windDirection.x, 0, value);
    }
}