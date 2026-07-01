using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WindPhysicsController : MonoBehaviour
{
    public DynamicWindController windController;

    private Rigidbody rb;

    public float windMultiplier = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (windController == null)
            return;

        Vector3 force = windController.windDirection.normalized *
                windController.windStrength *
                windMultiplier;

        rb.AddForce(force, ForceMode.Force);
    }
}