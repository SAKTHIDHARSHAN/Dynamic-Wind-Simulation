using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class LeafWindController : MonoBehaviour
{
    public DynamicWindController windController;

    private ParticleSystem ps;
    private ParticleSystem.VelocityOverLifetimeModule velocity;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        velocity = ps.velocityOverLifetime;
    }

    void Update()
    {
        Vector3 dir = windController.windDirection.normalized;

        velocity.x = dir.x * windController.windStrength;
        velocity.z = dir.z * windController.windStrength;
    }
}
