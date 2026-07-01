using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWindController : MonoBehaviour
{
    [Header("Wind Settings")]
    public WindZone windZone;

    [Header("Wind Direction")]
    public Vector3 windDirection = Vector3.right;

    [Range(0f, 5f)]
    public float windStrength = 1f;

    [Range(0f, 2f)]
    public float turbulence = 0.5f;

    [Range(0f, 2f)]
    public float pulseMagnitude = 0.5f;

    [Range(0f, 2f)]
    public float pulseFrequency = 0.5f;

    [Header("Natural Gusts")]
    public bool enableGusts = true;

    [Range(0f, 2f)]
    public float gustStrength = 0.5f;

    public float gustSpeed = 0.2f;

    void Update()
    {
        if (windZone == null)
            return;

        float finalStrength = windStrength;

        if (enableGusts)
        {
            float gust = Mathf.PerlinNoise(Time.time * gustSpeed, 0f);
            finalStrength += (gust - 0.5f) * gustStrength;
        }

        windZone.windMain = Mathf.Max(0, finalStrength);
        windZone.windTurbulence = turbulence;
        windZone.windPulseMagnitude = pulseMagnitude;
        windZone.windPulseFrequency = pulseFrequency;

        if (windDirection != Vector3.zero)
        {
            windZone.transform.rotation =
                Quaternion.LookRotation(windDirection.normalized);
        }
    }
}